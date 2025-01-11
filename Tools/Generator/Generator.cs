using System.Text.Json;

namespace Tools.Generator
{
    public class Generator
    {
        public List<string> Content { get; set; }
        public string Path { get; set; }
        public TypeFormat Format { get; set; }
        public TypeCharacter Character { get; set; }

        public void Save()
        {
            string result = Format == TypeFormat.Json ? GenerateJson() : GeneratePipes();

            if (Character == TypeCharacter.Uppercase) result = result.ToUpper();

            if (Character == TypeCharacter.LowerCase) result = result.ToLower();

            File.WriteAllText(Path, result);
        }

        private string GenerateJson() => JsonSerializer.Serialize(Content);
        private string GeneratePipes() => Content.Aggregate((acum, current) => $"{acum}|{current}");
    }
}
