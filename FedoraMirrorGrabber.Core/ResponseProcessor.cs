using System.Xml;

namespace FedoraMirrorGrabber.Core;

public class ResponseProcessor
{
  #region APIs

  public IEnumerable<Mirror> Run(string payload)
  {
    var doc = new XmlDocument();
    doc.LoadXml(payload);

    var nsMgr = new XmlNamespaceManager(doc.NameTable);
    nsMgr.AddNamespace("ns", "http://www.metalinker.org/");
    nsMgr.AddNamespace("mm0", "http://fedorahosted.org/mirrormanager");

    // url[@protocol='http']
    var nodes = doc.SelectNodes(@"/ns:metalink/ns:files/ns:file/ns:resources/ns:url", nsMgr);

    foreach (XmlElement node in nodes)
    {
      if (!Enum.TryParse<RepositoryType>(node.Attributes["type"].InnerText, true, out var type))
      {
        type = RepositoryType.Unknown;
      }
      yield return new Mirror(node.InnerText, type) ;
    }
  }

  #endregion
}