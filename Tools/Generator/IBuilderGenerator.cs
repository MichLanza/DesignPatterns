namespace Tools.Generator
{
    public interface IBuilderGenerator
    {
        public void Reset();
        public void SetContent(List<string> content);
        public void Path(string path);
        public void SetFormat(TypeFormat format);
        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);
    }
}
