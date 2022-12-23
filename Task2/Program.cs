using System.Globalization;
using System.Numerics;

const string answer = "192C352036755D6D7D2050776472264E6A7A21566F747666"; 
const string s1 = "506561636520416c6c204f7665722054686520576f726c64";
const string s2 = "4949544353551c0111001f010100061a021f010100061a02";

var s1Int = BigInteger.Parse(s1, NumberStyles.HexNumber);
var s2Int = BigInteger.Parse(s2, NumberStyles.HexNumber);
var retVal = s1Int ^ s2Int;
Console.WriteLine(retVal.ToString("X"));
Console.WriteLine(retVal.ToString("X") == answer);
