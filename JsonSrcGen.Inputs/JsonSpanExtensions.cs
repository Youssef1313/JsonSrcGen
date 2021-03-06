using System;
using System.Text;

namespace JsonSrcGen
{
    internal static class JsonSpanExtensions
    {
        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out bool value)
        {
            json = json.SkipWhitespace();
            switch(json[0])
            {
                case 't':
                    value = true;
                    return json.Slice(4);
                case 'f':
                    value = false;
                    return json.Slice(5);
            }
            throw new InvalidJsonException($"Expected 'true' or 'false' but got {new string(json)}");
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out bool? value)
        {
            json = json.SkipWhitespace();
            switch(json[0])
            {
                case 't':
                    value = true;
                    return json.Slice(4);
                case 'n':
                    value = null;
                    return json.Slice(4);
            }
            value = false;
            return json.Slice(5);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out short value)
        {
            json = json.SkipWhitespace();
            int sign = 1;
            int startIndex = 0;
            if(json[0] == '-')
            {
                sign = -1;
                startIndex = 1;
            }
            int afterIntIndex = 0;
            int soFar = 0;

            for(int index = startIndex; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int digit = ((int)character) - 48;
                        soFar *= 10;
                        soFar += digit; 
                        continue;
                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = (short)(sign * soFar);

            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out long? value)
        {
            json = json.SkipWhitespace();
            int sign = 1;
            int startIndex = 0;
            switch(json[0])
            {
                case '-':
                    sign = -1;
                    startIndex = 1;
                    break;
                case 'n':
                    value = null;
                    return json.Slice(4);
            }
            int afterIntIndex = 0;
            value = 0;
            for(int index = startIndex; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        long digit = ((long)character) - 48;
                        value *= 10;
                        value += digit; 
                        continue;
                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = sign * value;

            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out long value)
        {
            json = json.SkipWhitespace();
            int sign = 1;
            int startIndex = 0;
            if(json[0] == '-')
            {
                sign = -1;
                startIndex = 1;
            }
            int afterIntIndex = 0;
            value = 0;
            for(int index = startIndex; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        long digit = ((long)character) - 48;
                        value *= 10;
                        value += digit; 
                        continue;
                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = sign * value;

            return json.Slice(afterIntIndex);
        }


        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out int? value)
        {
            json = json.SkipWhitespace();
            int sign = 1;
            int startIndex = 0;

            switch(json[0])
            {
                case '-':
                    sign = -1;
                    startIndex = 1;
                    break;
                case 'n':
                    value = null;
                    return json.Slice(4);
            }

            int afterIntIndex = 0;
            int soFar = 0;

            for(int index = startIndex; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int digit = ((int)character) - 48;
                        soFar *= 10;
                        soFar += digit; 
                        continue;
                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = sign * soFar;

            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out int value)
        {
            json = json.SkipWhitespace();
            int sign = 1;
            int startIndex = 0;
            if(json[0] == '-')
            {
                sign = -1;
                startIndex = 1;
            }
            int afterIntIndex = 0;
            int soFar = 0;

            for(int index = startIndex; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int digit = ((int)character) - 48;
                        soFar *= 10;
                        soFar += digit; 
                        continue;
                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = sign * soFar;

            return json.Slice(afterIntIndex);
        }

        static bool IsNumber(char character)
        {
            return character >= '0' && character <= '9';
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out double? value)
        {
            json = json.SkipWhitespace();

            int index = 0;
            int sign = 1;
            char character = ' ';

            switch(json[0])
            {
                case '-':
                    sign = -1;
                    index++;
                    break;
                case 'n':
                    value = null;
                    return json.Slice(4);
            }

            double wholePart = 0;
            for(; index < json.Length; index++)
            {
                character = json[index];
                if(!IsNumber(character)) break;
                wholePart = (wholePart*10) + character - '0';
            }

            double fractionalPart = 0;
            if(character == '.')
            {
                long fractionalValue = 0;
                int factionalLength = 0;
                for(index = index+1; index < json.Length; index++)
                {
                    character = json[index];
                    if(!IsNumber(character)) break;
                    fractionalValue = (fractionalValue*10) + character - '0';
                    factionalLength++;
                }
                double divisor = Math.Pow(10, factionalLength);
                fractionalPart = fractionalValue/divisor;
            }

            int exponentPart = 0;
            if(character == 'E' || character == 'e')
            {
                index++;
                character = json[index];
                int exponentSign = 1;
                if(character == '-')
                {
                    index++;
                    exponentSign = -1;
                }
                else if(character == '+')
                {
                    index++;
                }

                for(; index < json.Length; index++)
                {
                    character = json[index];
                    if(!IsNumber(character)) break;
                    exponentPart = (exponentPart*10) + character - '0';
                }

                exponentPart *= exponentSign;
            }
            else
            {
                value =  sign*(wholePart + fractionalPart);
                return json.Slice(index);
            }
            value = sign*(wholePart + fractionalPart) * Math.Pow(10, exponentPart);
            return json.Slice(index);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out double value)
        {
            json = json.SkipWhitespace();

            int index = 0;
            int sign = 1;
            char character = ' ';

            if(json[index] == '-')
            {
                sign = -1;
                index++;
            }

            double wholePart = 0;
            for(; index < json.Length; index++)
            {
                character = json[index];
                if(!IsNumber(character)) break;
                wholePart = (wholePart*10) + character - '0';
            }

            double fractionalPart = 0;
            if(character == '.')
            {
                long fractionalValue = 0;
                int factionalLength = 0;
                for(index = index+1; index < json.Length; index++)
                {
                    character = json[index];
                    if(!IsNumber(character)) break;
                    fractionalValue = (fractionalValue*10) + character - '0';
                    factionalLength++;
                }
                double divisor = Math.Pow(10, factionalLength);
                fractionalPart = fractionalValue/divisor;
            }

            int exponentPart = 0;
            if(character == 'E' || character == 'e')
            {
                index++;
                character = json[index];
                int exponentSign = 1;
                if(character == '-')
                {
                    index++;
                    exponentSign = -1;
                }
                else if(character == '+')
                {
                    index++;
                }

                for(; index < json.Length; index++)
                {
                    character = json[index];
                    if(!IsNumber(character)) break;
                    exponentPart = (exponentPart*10) + character - '0';
                }

                exponentPart *= exponentSign;
            }
            else
            {
                value =  sign*(wholePart + fractionalPart);
                return json.Slice(index);
            }
            value = sign*(wholePart + fractionalPart) * Math.Pow(10, exponentPart);
            return json.Slice(index);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out byte value)
        {
            json = json.SkipWhitespace();
            int afterIntIndex = 0;
            value = 0;
            for(int index = 0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        byte digit = (byte)(((byte)character) - 48);
                        value *= 10;
                        value += digit; 
                        continue;

                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out ushort value)
        {
            json = json.SkipWhitespace();
            int afterIntIndex = 0;
            int soFar = 0;
            for(int index =0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int digit = ((int)character) - 48;
                        soFar *= 10;
                        soFar += digit; 
                        continue;

                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = (ushort)soFar;

            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out ulong? value)
        {
            json = json.SkipWhitespace();
            if(json[0] == 'n')
            {
                value = null;
                return json.Slice(4);
            }
            int afterIntIndex = 0;
            value = 0;
            for(int index =0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        ulong digit = ((ulong)character) - 48;
                        value *= 10;
                        value += digit; 
                        continue;

                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out ulong value)
        {
            json = json.SkipWhitespace();
            int afterIntIndex = 0;
            value = 0;
            for(int index =0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        ulong digit = ((ulong)character) - 48;
                        value *= 10;
                        value += digit; 
                        continue;

                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out uint? value)
        {
            json = json.SkipWhitespace();
            if(json[0] == 'n')
            {
                value = null;
                return json.Slice(4);
            }
            int afterIntIndex = 0;
            int soFar = 0;
            for(int index =0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int digit = ((int)character) - 48;
                        soFar *= 10;
                        soFar += digit; 
                        continue;

                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = (uint)soFar;

            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out uint value)
        {
            json = json.SkipWhitespace();
            int afterIntIndex = 0;
            int soFar = 0;
            for(int index =0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int digit = ((int)character) - 48;
                        soFar *= 10;
                        soFar += digit; 
                        continue;

                    default:
                        afterIntIndex = index;
                        break;
                }
                break;
            }
            
            value = (uint)soFar;

            return json.Slice(afterIntIndex);
        }

        public static ReadOnlySpan<char> Read(this ReadOnlySpan<char> json, out string value)
        {
            json = json.SkipWhitespaceTo('\"', 'n', out char found);
            if(found == 'n')
            {
                value = null;
                return json.Slice(3);
            }
            for(int index = 0; index < json.Length; index++)
            {
                switch(json[index])
                {
                    case '\\':
                        json = ReadEscapedString(json, index, out value);
                        return json;
                    case '\"':
                        value = new string(json.Slice(0, index));
                        return json.Slice(index+1);
                }
            }
            throw new InvalidJsonException("Failed to find end of string");
        }

        [ThreadStatic]
        static StringBuilder _builder;

        static ReadOnlySpan<char> ReadEscapedString(this ReadOnlySpan<char> json, int firstEscapeCharacterIndex, out string value)
        {
            var builder = _builder;
            if(_builder == null)
            {
                _builder = new StringBuilder();
                builder = _builder;
            }
            builder.Clear();
            int index = firstEscapeCharacterIndex;
            while(true)
            {
                char character = json[index];

                if(character == '\\')
                {
                    _builder.Append(json.Slice(0, index)); //append
                    //escape character
                    index++;
                    character = json[index];
                    switch(character)
                    {
                        case '\"':
                        case '\\':
                        case '/':
                            Console.WriteLine($"Appending {character}");
                            _builder.Append(character);
                            break;
                        case 'b':
                            _builder.Append('\b');
                            break;
                        case 'f':
                            _builder.Append('\f');
                            break;
                        case 'n':
                            _builder.Append('\n');
                            break;
                        case 'r':
                            _builder.Append('\r');
                            break;
                        case 't':
                            _builder.Append('\t');
                            break;
                        case 'u':
                            index++;
                            _builder.Append(FromHex(json, index));
                            index += 3;
                            break;
                    }

                    json = json.Slice(index + 1);
                    index = 0;
                    continue;
                }
                else if(character == '\"')
                {
                    //end of string value
                    _builder.Append(json.Slice(0, index));
                    value = builder.ToString();
                    return json.Slice(index + 1);
                }
                index++;
                
            }
            //we got to the end of the span without finding the end of string character
            throw new InvalidJsonException("Missing end of string value");
        }

        static char FromHex(this ReadOnlySpan<char> json, int internalStart)
        {
            int value =
                (FromHexChar(json[internalStart]) << 12) +
                (FromHexChar(json[internalStart + 1]) << 8) +
                (FromHexChar(json[internalStart + 2]) << 4) +
                (FromHexChar(json[internalStart + 3]));
            return (char)value;
        }

        public static ReadOnlySpan<char> SkipWhitespace(this ReadOnlySpan<char> json)
        {
            for(int index = 0; index < json.Length; index++)
            {
                var value = json[index];
                switch(value)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        continue;
                }
                return json.Slice(index);
            }
            throw new InvalidJsonException($"Unexpected end of json while skipping whitespace");
        }

        public static ReadOnlySpan<char> SkipWhitespaceTo(this ReadOnlySpan<char> json, char to)
        {
            for(int index = 0; index < json.Length; index++)
            {
                var value = json[index];
                switch(value)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        continue;
                }
                if(value == to)
                {
                    index++;
                    return json.Slice(index);
                }
                throw new InvalidJsonException($"Unexpected character! expected '{to}' but got '{value}' in '{new string(json)}'");
            }
            throw new InvalidJsonException($"Unexpected end of json while looking for '{to}'");
        }

        public static ReadOnlySpan<char> SkipWhitespaceTo(this ReadOnlySpan<char> json, char to1, char to2, out char found)
        {
            for(int index = 0; index < json.Length; index++)
            {
                var value = json[index];
                switch(value)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        continue;
                }
                if(value == to1)
                {
                    index++;
                    found = to1;
                    return json.Slice(index);
                }
                if(value == to2)
                {
                    index++;
                    found = to2;
                    return json.Slice(index);
                }
                throw new InvalidJsonException($"Unexpected character! expected '{to1}' or '{to2}' but got '{value}' at {new string(json)}");
            }
            throw new InvalidJsonException($"Unexpected end of json while looking for '{to1}' or {to2}");
        }

        public static ReadOnlySpan<char> SkipProperty(this ReadOnlySpan<char> json)
        {
            int numberOfOpenBrackets = 0;

            bool inString = false;

            for(int index = 0; index < json.Length; index++)
            {
                var character = json[index];
                switch(character)
                {
                    case '{':
                        numberOfOpenBrackets++;
                        break;
                    case '}':
                        if(numberOfOpenBrackets == 0)
                        {
                            //end of class that the property is in
                            return json.Slice(index);
                        }
                        numberOfOpenBrackets--;
                        break;
                    case '\"':
                        inString = !inString;
                        break;
                    case ',':
                        if(numberOfOpenBrackets == 0 && !inString)
                        {
                            return json.Slice(index);
                        }
                        break;
                }
            }
            throw new InvalidJsonException($"Failed to find end of property at {new string(json)}");
        }

        public static ReadOnlySpan<char> ReadTo(this ReadOnlySpan<char> json, char to)
        {
            for(int index = 0; index < json.Length; index++)
            {
                var value = json[index];
                if(value == to)
                {
                    return json.Slice(0, index);
                }
            }
            throw new InvalidJsonException($"Unexpected end of json while looking for '{to}'");
        }

        public static bool EqualsString(this ReadOnlySpan<char> json, string other)
        {
            if(json.Length != other.Length)
            {
                return false;
            }
            for(int index = 0; index < 0; index++)
            {
                if(json[0] != other[0])
                {
                    return false;
                }
            }
            return true;
        }

        public static ReadOnlySpan<char> ReadDateTime(this ReadOnlySpan<char> json, out DateTime value)
        {
            int index = 0;

            json = json.SkipWhitespace();

            if(json[0] != '\"')
            {
                throw new InvalidJsonException($"Expected DateTime property to start with a quote but instead got '{json[0]}'");
            }
            json = json.Slice(1);

            int year = 
                (json[0] - 48)*1000 + 
                (json[1] - 48)*100 +
                (json[2] - 48)*10 +
                (json[3] - 48);
            int month =
                (json[5] - 48)*10 +
                (json[6] - 48);
            int day =
                (json[8] - 48)*10 +
                (json[9] - 48);

            if(json[index + 10] == '\"')
            {
                value = new DateTime(year, month, day);
                return json.Slice(11);
            }

            int hour =
                (json[11] - 48)*10 +
                (json[12] - 48);

            int minute =
                (json[14] - 48)*10 +
                (json[15] - 48);

            int second =
                (json[17] - 48)*10 +
                (json[18] - 48);

            
            index += 19;
            var character = json[index];
            if(character == '\"')
            {
                value = new DateTime(year, month, day, hour, minute, second);
                return json.Slice(20);
            }

            double milliseonds = 0;
            if(character == '.')
            {
                index++;
                //milliseconds
                int subSeconds = 0;
                int millisecondsStart = index;
                
                while(true)
                {
                    character = json[index];
                    if(character >= '0' && character <= '9')
                    {
                        subSeconds = (subSeconds * 10) + (character - 48);
                        index++;
                    }
                    else
                    {
                        int millisecondsLength = index - millisecondsStart;
                        double multiplier = 1;
                        switch(millisecondsLength)
                        {
                            case 1: 
                                multiplier = 100;
                                break;
                            case 2:
                                multiplier = 10;
                                break;
                            case 3:
                                multiplier = 1;
                                break;
                            case 4:
                                multiplier = 0.1d;
                                break;
                            case 5:
                                multiplier = 0.01d;
                                break;
                            case 6:
                                multiplier = 0.001d;
                                break;
                            case 7:
                                multiplier = 0.0001d;
                                break;
                            case 8:
                                multiplier = 0.00001d;
                                break;
                        }
                        milliseonds = subSeconds*multiplier;
                        break;
                    }
                }
            }
            DateTimeKind kind = DateTimeKind.Unspecified;
            if(character == '\"')
            {

            }
            else if(character == 'Z')
            {
                kind = DateTimeKind.Utc;
                index++;
            }
            else
            {
                int offsetSign = character == '-' ? -1 : 1;
                int offsetHours = 
                    (json[index + 1] - 48)*10 +
                    (json[index + 2] - 48);
                int offsetMinutes = 
                    (json[index + 4] - 48)*10 +
                    (json[index + 5] - 48);
                var offset = new TimeSpan(offsetSign*offsetHours, offsetMinutes, 0);
                var localDateTime = new DateTimeOffset(year, month, day, hour, minute, second, offset).AddMilliseconds(milliseonds).LocalDateTime;
                value = localDateTime;
                return json.Slice(index + 7);
            }

            value = new DateTime(year, month, day, hour, minute, second, kind).AddMilliseconds(milliseonds);
            return json.Slice(index + 1);
        }

        public static ReadOnlySpan<char> ReadNullableDateTime(this ReadOnlySpan<char> json, out DateTime? value)
        {
            int index = 0;

            json = json.SkipWhitespace();

            switch(json[0])
            {
                case 'n':
                     value = null;
                     return json.Slice(4);
                case '\"':
                    break;
                default:
                    throw new InvalidJsonException($"Expected DateTime property to start with a quote but instead got '{json[0]}'");
            }

            json = json.Slice(1);

            int year = 
                (json[0] - 48)*1000 + 
                (json[1] - 48)*100 +
                (json[2] - 48)*10 +
                (json[3] - 48);
            int month =
                (json[5] - 48)*10 +
                (json[6] - 48);
            int day =
                (json[8] - 48)*10 +
                (json[9] - 48);

            if(json[index + 10] == '\"')
            {
                value = new DateTime(year, month, day);
                return json.Slice(11);
            }

            int hour =
                (json[11] - 48)*10 +
                (json[12] - 48);

            int minute =
                (json[14] - 48)*10 +
                (json[15] - 48);

            int second =
                (json[17] - 48)*10 +
                (json[18] - 48);

            
            index += 19;
            var character = json[index];
            if(character == '\"')
            {
                value = new DateTime(year, month, day, hour, minute, second);
                return json.Slice(20);
            }

            double milliseonds = 0;
            if(character == '.')
            {
                index++;
                //milliseconds
                int subSeconds = 0;
                int millisecondsStart = index;
                
                while(true)
                {
                    character = json[index];
                    if(character >= '0' && character <= '9')
                    {
                        subSeconds = (subSeconds * 10) + (character - 48);
                        index++;
                    }
                    else
                    {
                        int millisecondsLength = index - millisecondsStart;
                        double multiplier = 1;
                        switch(millisecondsLength)
                        {
                            case 1: 
                                multiplier = 100;
                                break;
                            case 2:
                                multiplier = 10;
                                break;
                            case 3:
                                multiplier = 1;
                                break;
                            case 4:
                                multiplier = 0.1d;
                                break;
                            case 5:
                                multiplier = 0.01d;
                                break;
                            case 6:
                                multiplier = 0.001d;
                                break;
                            case 7:
                                multiplier = 0.0001d;
                                break;
                            case 8:
                                multiplier = 0.00001d;
                                break;
                        }
                        milliseonds = subSeconds*multiplier;
                        break;
                    }
                }
            }
            DateTimeKind kind = DateTimeKind.Unspecified;
            if(character == '\"')
            {

            }
            else if(character == 'Z')
            {
                kind = DateTimeKind.Utc;
                index++;
            }
            else
            {
                int offsetSign = character == '-' ? -1 : 1;
                int offsetHours = 
                    (json[index + 1] - 48)*10 +
                    (json[index + 2] - 48);
                int offsetMinutes = 
                    (json[index + 4] - 48)*10 +
                    (json[index + 5] - 48);
                var offset = new TimeSpan(offsetSign*offsetHours, offsetMinutes, 0);
                var localDateTime = new DateTimeOffset(year, month, day, hour, minute, second, offset).AddMilliseconds(milliseonds).LocalDateTime;
                value = localDateTime;
                return json.Slice(index + 7);
            }

            value = new DateTime(year, month, day, hour, minute, second, kind).AddMilliseconds(milliseonds);
            return json.Slice(index + 1);
        }

        public static byte FromHexChar(char character)
        {
            switch(character)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'a': return 10;
                case 'A': return 10;
                case 'b': return 11;
                case 'B': return 11;
                case 'c': return 12;
                case 'C': return 12;
                case 'd': return 13;
                case 'D': return 13;
                case 'e': return 14;
                case 'E': return 14;
                case 'f': return 15;
                case 'F': return 15;
                default: 
                    throw new InvalidJsonException("character must be a hex value");
            }
        }

        public static ReadOnlySpan<char> ReadGuid(this ReadOnlySpan<char> json, out Guid value)
        {
            json.SkipWhitespace();

            if(json[0] != '\"')
            {
                throw new InvalidJsonException($"Expected DateTime property to start with a quote but instead got '{json[0]}'");
            }
            json = json.Slice(1);

            uint a =
                ((uint)FromHexChar(json[0]) << 28) + 
                ((uint)FromHexChar(json[1]) << 24) + 
                (uint)(FromHexChar(json[2]) << 20) +
                (uint)(FromHexChar(json[3]) << 16) +
                (uint)(FromHexChar(json[4]) << 12) +
                (uint)(FromHexChar(json[5]) << 8) +
                (uint)(FromHexChar(json[6]) << 4) +
                (uint)FromHexChar(json[7]);
            
            ushort b = (ushort)
                ((FromHexChar(json[9]) << 12) +
                (FromHexChar(json[10]) << 8) +
                (FromHexChar(json[11]) << 4) +
                FromHexChar(json[12]));

            ushort c = (ushort)
                ((FromHexChar(json[14]) << 12) +
                (FromHexChar(json[15]) << 8) +
                (FromHexChar(json[16]) << 4) +
                FromHexChar(json[17]));

            byte d = (byte)((FromHexChar(json[19]) << 4) + FromHexChar(json[20]));
            byte e = (byte)((FromHexChar(json[21]) << 4) + FromHexChar(json[22]));

            byte f = (byte)((FromHexChar(json[24]) << 4) + FromHexChar(json[25]));
            byte g = (byte)((FromHexChar(json[26]) << 4) + FromHexChar(json[27]));
            byte h = (byte)((FromHexChar(json[28]) << 4) + FromHexChar(json[29]));
            byte i = (byte)((FromHexChar(json[30]) << 4) + FromHexChar(json[31]));
            byte j = (byte)((FromHexChar(json[32]) << 4) + FromHexChar(json[33]));
            byte k = (byte)((FromHexChar(json[34]) << 4) + FromHexChar(json[35]));

            value = new Guid(a, b, c, d, e, f, g, h, i, j, k);

            return json.Slice(37);
        }

        public static ReadOnlySpan<char> ReadNullableGuid(this ReadOnlySpan<char> json, out Guid? value)
        {
            json.SkipWhitespace();

            switch(json[0])
            {
                case 'n':
                     value = null;
                     return json.Slice(4);
                case '\"':
                    break;
                default:
                    throw new InvalidJsonException($"Expected Guid property to start with a quote but instead got '{json[0]}'");
            }
            json = json.Slice(1);

            uint a =
                ((uint)FromHexChar(json[0]) << 28) + 
                ((uint)FromHexChar(json[1]) << 24) + 
                (uint)(FromHexChar(json[2]) << 20) +
                (uint)(FromHexChar(json[3]) << 16) +
                (uint)(FromHexChar(json[4]) << 12) +
                (uint)(FromHexChar(json[5]) << 8) +
                (uint)(FromHexChar(json[6]) << 4) +
                (uint)FromHexChar(json[7]);
            
            ushort b = (ushort)
                ((FromHexChar(json[9]) << 12) +
                (FromHexChar(json[10]) << 8) +
                (FromHexChar(json[11]) << 4) +
                FromHexChar(json[12]));

            ushort c = (ushort)
                ((FromHexChar(json[14]) << 12) +
                (FromHexChar(json[15]) << 8) +
                (FromHexChar(json[16]) << 4) +
                FromHexChar(json[17]));

            byte d = (byte)((FromHexChar(json[19]) << 4) + FromHexChar(json[20]));
            byte e = (byte)((FromHexChar(json[21]) << 4) + FromHexChar(json[22]));

            byte f = (byte)((FromHexChar(json[24]) << 4) + FromHexChar(json[25]));
            byte g = (byte)((FromHexChar(json[26]) << 4) + FromHexChar(json[27]));
            byte h = (byte)((FromHexChar(json[28]) << 4) + FromHexChar(json[29]));
            byte i = (byte)((FromHexChar(json[30]) << 4) + FromHexChar(json[31]));
            byte j = (byte)((FromHexChar(json[32]) << 4) + FromHexChar(json[33]));
            byte k = (byte)((FromHexChar(json[34]) << 4) + FromHexChar(json[35]));

            value = new Guid(a, b, c, d, e, f, g, h, i, j, k);

            return json.Slice(37);
        }
    }
}