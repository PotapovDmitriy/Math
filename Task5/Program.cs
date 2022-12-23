using System.Text;

// Чтение файла я заменил обычной константой, вроде строка не самая большая
const string text = "Shannon contributed to the field of cryptanalysis for national defense during World War II, \nincluding his basic work on codebreaking and secure telecommunications.";
const string key = "Shannon";
const string answer = "00000000000000730b0e001a1d07311d150b0a4f1a3c4815060b4f083a0d0d0a4e0008730b13171e1b0f3d090d171d061d730e0e1c4e010f27010e000f034e370d070b001c0b730c141c070109733f0e1c020b4e0409134e272642736208000d031b37010f094e07072048030f1d060d731f0e1c054f013d4802010a0a0c210d000507010973090f0a4e1c0b301d130b4e1b0b3f0d020103021b3d01020f1a06013d1b4f";

// Фукнция получения повторяемого ключа
string GetRepeatKey(string s, int n)
{
    var r = s;
    while (r.Length < n)
    {
        r += r;
    }

    return r.Substring(0, n);
}

// Функция шифрования заданных строк
string Encrypt(string innerText, string secretKey)
{
    var currentKey = GetRepeatKey(secretKey, innerText.Length);
    var keyBytes = Encoding.ASCII.GetBytes(currentKey); //Получение массива байт из строки
    var textBytes = Encoding.ASCII.GetBytes(innerText);
    var res = string.Empty;
    for (var i = 0; i < textBytes.Length; i++)
    {
        // XOR для байт и преобразование в строку в шестнадцатеричном виде
        var enc = (textBytes[i] ^ keyBytes[i]).ToString("x");
        // так как c# немного неверно преобразовал в шестнадцатеричном то решил применить такой костыль
        res += enc.Length == 1  ? "0" + enc  : enc; 
    }

    return res;
}


var encryptedMessageByPass = Encrypt(text, key);
Console.WriteLine(encryptedMessageByPass);
Console.WriteLine(answer);

// Сравнение с предоставленным результатом
Console.WriteLine(encryptedMessageByPass == answer);