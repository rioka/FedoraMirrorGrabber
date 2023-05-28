using FedoraMirrorGrabber.Core;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace FedoraMirrorGrabber.App.Execute;

public sealed class Settings : CommandSettings
{
  [CommandOption("-r|--release-version")]
  public int ReleaseVersion { get; set; }
  
  [CommandOption("-a|--architecture ")]
  [Description("Architecture")]
  [DefaultValue("x86_64")]
  public string Architecture { get; set; }  

  [CommandOption("-p|--protocol")]
  [Description("Type of mirrors to include")]
  public RepositoryType[]? Protocols { get; set; }

  [CommandOption("-o|--output-file ")]
  [Description("File to save result to")]
  [DefaultValue("fedora.db")]
  public string SaveTo { get; set; }
}