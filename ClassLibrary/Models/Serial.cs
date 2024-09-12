using System.ComponentModel;

namespace ClassLibrary.Models;

public class Serial
{
    public Serial(string serialNumber, int usageCount)
    {
        SerialNumber = serialNumber;
        UsageCount = usageCount;
    }
    
    public Serial()
    {
    }

    [DisplayName("Serial number")]
    public string SerialNumber { get; set; }
    
    [DisplayName("Usage count")]
    public int UsageCount { get; set; }
}