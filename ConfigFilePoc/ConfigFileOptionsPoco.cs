using System;

namespace ConfigFilePoc
{
  public class ConfigFileOptionsPoco
  {
    public bool Enabled { get; set; }
    public TimeSpan AutoRetryDelay { get; set; }
  }
}