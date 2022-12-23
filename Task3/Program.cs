using System.Globalization;
using System.Numerics;
using System.Text;

const string inputString = "19367831362e3d2b2c353d362c783136783336372f343d3c3f3d7839342f39212b782839212b782c303d783a3d2b2c7831362c3d2a3d2b2c";

var res = new Dictionary<string, int>();

// Фунцкция XOR для шестнадцатиричной системы
static string XoR(string str1, string str2)
{
    BigInteger s1Int = BigInteger.Parse(str1, NumberStyles.HexNumber);
    BigInteger s2Int = BigInteger.Parse(str2, NumberStyles.HexNumber);
    BigInteger retVal = s1Int ^ s2Int;
    
    return retVal.ToString("x");
}

// Так как это была шестнадцатиричная система счисления то шаг делаем по 2 символа и получаем необходимый массив строк
// сгруппированый по частоте встречаемости
for (var i = 0; i < inputString.Length; i += 2)
{
    var end = i + 2;
    if (inputString.Length > i && inputString.Length > end)
    {
        var subStr = inputString[i..end];
        if (res.ContainsKey(subStr))
            res[subStr]++;
        else
            res[subStr] = 1;
    }
}

// Часто встречаемый элемент
var maxValue = res.Values.Max();

// Получаем самые часто встречаемый ключи
var allKeys = new List<string>();
foreach (var (key, value) in res)
{
    if (value == maxValue)
        allKeys.Add(key);
}

// Самый часто встречаемый символ в английском языке
var mostChar = Encoding.ASCII.GetBytes("e").First().ToString("X");
// Получим ключи для декодирования
var resKeys = allKeys.Select(k => XoR(mostChar, k)).ToList();

// Разобьем входную строку на символы для декодирования
var resInput = new List<string>();
for (var i = 0; i < inputString.Length; i += 2)
{
    var end = i + 2;
    if (inputString.Length > i && inputString.Length > end)
    {
        var subStr = inputString[i..end];
        resInput.Add(subStr);
    }
}

// Декодирую использую выявленные ключи 
var resList = new List<List<char>>();
var count = 0;
foreach (var key in resKeys)
{
    resList.Add(new List<char>());
    foreach (var r in resInput)
    {
        resList[count].Add((char) BigInteger.Parse(XoR(key, r), NumberStyles.HexNumber));
    }

    count++;
}

resList.ForEach(i => Console.WriteLine(string.Join("", i)));

// Можно заетить что второй ключ оказался верным и получим результат
Console.WriteLine($"Валидный результат: {string.Join("", resList[1])}");