using CommandLine;
using FedoraMirrorGrabber.Core;

namespace FedoraMirrorGrabber.App;

internal class Options  
{
  // [Option('u', "url", HelpText = "Url to get list of mirrors", Default = "https://mirrors.fedoraproject.org/")]
  // public string Url { get; set; }

  [Option('a', "architecture", HelpText = "Architecture", Default = "x86_64")]
  public string Architecture { get; set; } = "x86_64";

  [Option('r', "release-version", HelpText = "Fedora release", Default = 42)]
  public int ReleaseVersion { get; set; } = 42;

  [Option('o', "output-file", HelpText = "Name of the file where data is saved to", Default = "fedora.db")]
  public string SaveTo { get; set; } = "fedora.db";
  
  [Option('p', "protocol", HelpText = "Type of mirrors to include", Separator = ',')]
  public IEnumerable<RepositoryType>? Protocols { get; set; }   
}