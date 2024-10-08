using ClassLibrary.Interfaces;
using System.Text;
using ClassLibrary.Models;
using Newtonsoft.Json;

namespace ClassLibrary.Brokers;

public class DrawBroker : BaseBroker, IDrawService
{
    private const string baseUri = "http://service.draw:8080/Home";
    
    public bool Get()
    {
        var t = Get<bool>(baseUri+"/Get");
        if (t != null) return t.Result;
        return false;
    }

    public Draw? SubmitDraw(Draw draw)
    {
        var content = new StringContent(JsonConvert.SerializeObject(draw), Encoding.UTF8, "application/json");
        var t = Post<Draw>(baseUri+"/SubmitDraw", content);
        if (t != null) return t.Result;
        return null;
    }

    public IEnumerable<Draw> ListDraws()
    {
        var t = Get<Draw[]>(baseUri+"/ListDraws");
        if (t != null) return new List<Draw>(t.Result);
        return null;
    }

    public bool ValidateSerialNumber(string serialNumber)
    {
        var encodedSerialNumber = Uri.EscapeDataString(serialNumber);
        var t = Get<bool>(baseUri+"/ValidateSerialNumber/"+encodedSerialNumber);
        if (t != null) return t.Result;
        return false;
    }
}