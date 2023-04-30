using CommandLine;
using FedoraMirrorGrabber.Core;

namespace FedoraMirrorGrabber.App;

internal class Options  
{
  [Option('u', "url", HelpText = "Url to get list of mirrors", Default = "https://mirrors.fedoraproject.org/")]
  public string Url { get; set; }
  
  [Option('a', "architecture", HelpText = "Architecture", Default = "x86_64")]
  public string Architecture { get; set; }  
  
  [Option('r', "release-version", HelpText = "Fedora release", Default = 38)]
  public int ReleaseVersion { get; set; }
  
  [Option('o', "output-file", HelpText = "Name of the file where data is saved to", Default = "fedora.db")]
  public string SaveTo { get; set; }
  
  [Option('p', "protocol", HelpText = "Type of mirrors to include", Separator = ',')]
  public IEnumerable<RepositoryType>? Protocols { get; set; }   
}