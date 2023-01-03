# Digbyswift.Extensions

[![NuGet version (Digbyswift.Extensions)](https://img.shields.io/nuget/v/Digbyswift.Extensions.svg)](https://www.nuget.org/packages/Digbyswift.Extensions/)

A library of general-use extensions for everyday coding.

## Enumerable

- `IsEmpty()`
- `WhereNotNull()`
- `NotContains(T item)`
- `None(Func<T, bool> func)`
- `MinOrDefault()`
- `MaxOrDefault()`
- `CountIs(int count)`
- `CountIsGt(int count)`
- `CountIsGe(int count)`
- `CountIsLt(int count)`
- `CountIsLe(int count)`

## List

- `Crop(int toSize)`

## Dictionary

- `Set(TKey key, TValue value)`
- `ContainsKeyAndValue(TKey key, TValue value)`
- `ContainsKeyAndValue(TKey key, string value, StringComparison stringComparison = StringComparison.CurrentCulture)`
- `GetOrDefault(TKey key, TValue defaultValue)`
- `GetOrNull(TKey key)`

## NameValueCollection

- `ToDictionary()`
- `CopyTo(IDictionary<string, string?> dict)`
- `ToQueryString()`

## String

- `Coalesce(string? valueWhenNullOrEmpty)`
- `EqualsIgnoreCase(string toCheck)`
- `Contains(string toCheck, StringComparison comp)`
- `ContainsIgnoreCase(string toCheck)`
- `ContainsIgnoreCase(this IEnumerable<string> value, string toCheck)`
- `RemoveWhitespace()`
- `ToBool()`
- `Truncate(int length)`
- `Truncate(int length, string suffix)`
- `TruncateAtWord(this string input, int length)`
- `TruncateAtWord(this string input, int length, string suffix)`
- `ToUrlFriendly()`
- `TrimWithin()`
- `TrimToDefault(string? defaultValue = null)`
- `SplitAndTrim(params char[]? separator)`
- `StripMarkup()`
- `ReplaceExcess()`
- `Base64Encode()`
- `Base64Decode()`
- `MaskRight(int numberOfVisibleCharacter)`
- `MaskLeft(int numberOfVisibleCharacter)`
- `ToEnum()`

## String validation

- `IsEmail()`
- `IsUrl()`
- `IsIPv4()`
- `IsIPv6()`
- `IsWholeNumber()`
- `IsNumeric()`
- `IsAlphaNumeric()`
- `IsUkTelephone()`
- `IsMarkup()`
- `IsJson()`
- `HasFileExtension()`
- `ContainsEmail()`
- `ContainsUrl()`
- `ContainsIPv4()`
- `ContainsIPv6()`
- `ContainsUkTelephone()`
- `ContainsMarkup()`

## String compression (GZip)

- `Compress()`
- `Decompress()`

## Boolean

- `AsYesNo()`
- `AsYesNo(string nullDefault)`

## DateTime

- `GetDaysUntil()`
- `GetAgeNextBirthday()`
- `GetAge()`

## Numeric

- `IsZero()`
- `IsEven()`
- `AsPercentageOf(int total)`
- `AsPercentageOf(decimal total)`
- `AsPercentageOf(double total)`

## Encryption

- `RSAEncrypt()`
- `RSAEncrypt(this string text, string publicKeyXml()`
- `RSADecrypt()`
- `RSADecrypt(string privateKeyXml)`

## Third-party

### Youtube

- `IsYouTubeUrl()`
- `ExtractYouTubeVideoId()`
- `ToYouTubeThumbnailUrl()`
- `ToYouTubeEmbedUrl()`
- `ParseYoutubeQueryString()`

### Vimeo

- `IsVimeoUrl()`
- `IsVimeoEventUrl()`
- `ExtractVimeoVideoId()`
- `ToVimeoEmbedUrl()`

### Twitter

- `IsTweetUrl()`
- `ExtractIdFromTweetUrl()`