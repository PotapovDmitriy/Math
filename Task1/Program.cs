 string HexToBase64(string strInput)
{
    try
    {
        var bytes = new byte[strInput.Length / 2];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(strInput.Substring(i * 2, 2), 16);
        }
        return Convert.ToBase64String(bytes);
    }
    catch (Exception)
    {
        return "-1";
    }
}

const string src = "49276d207374756479696e672043727970746f677261706879206c696b6520436c6175646520456c776f6f64205368616e6e6f6e21";
const string answer = "SSdtIHN0dWR5aW5nIENyeXB0b2dyYXBoeSBsaWtlIENsYXVkZSBFbHdvb2QgU2hhbm5vbiE=";
Console.WriteLine(HexToBase64(src));
Console.Write(HexToBase64(src) == answer);
