using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

// Чтение файла
var lines = File.ReadLines(@"D:\rider projects\DictionaryByBinaryTree\ConsoleApp1\Task4\task140.input");

// Функция для вычисление повторяемого ключа нужной длины
string GetRepeatKey(string s, int n)
{
    var r = s;
    while (r.Length < n)
    {
        r += r;
    }

    return r.Substring(0, n);
}

// Функция конвертирования строки в массив байт
static byte[] ConvertHexStringToByteArray(string hexString)
{
    if (hexString.Length % 2 != 0)
    {
        throw new ArgumentException(String.Format(CultureInfo.InvariantCulture,
            "The binary key cannot have an odd number of digits: {0}", hexString));
    }

    var data = new byte[hexString.Length / 2];
    for (var index = 0; index < data.Length; index++)
    {
        var byteValue = hexString.Substring(index * 2, 2);
        data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
    }

    return data;
}

// Функция дешифратора
string Decrypt(string encryptedText, string password)
{
    var textBytes = ConvertHexStringToByteArray(encryptedText);
    var currentKey = GetRepeatKey(password, encryptedText.Length);
    var keyBytes = Encoding.ASCII.GetBytes(currentKey);
    var res = string.Empty;
    for (var i = 0; i < textBytes.Length; i++)
    {
        var enc = Convert.ToChar(textBytes[i] ^ keyBytes[i]);
        res += enc;
    }

    return res;
}

var resultStrings = new List<string>();

// Я решил использовать обычный брутфорс для получения результата
foreach (var line in lines)
{
    for (byte i = 65; i < 127; i++)
    {
        var pass = Encoding.ASCII.GetString(new[] { i });
        var test = Decrypt(line, pass);
        // Фильтруем полученные строки для того чтобы отделить невалидные 
        var regex = new Regex(@"^[a-z0-9\s\n]*$", RegexOptions.IgnoreCase); 
        if (regex.IsMatch(test))
            resultStrings.Add(test);
    }
}

Console.WriteLine($"Расшифрованное сообщение: {resultStrings.FirstOrDefault()}");