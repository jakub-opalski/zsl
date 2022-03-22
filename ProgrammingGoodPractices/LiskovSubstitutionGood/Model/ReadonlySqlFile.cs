namespace LiskovSubstitutionGood.Model
{
    public class ReadonlySqlFile : IReadableSqlFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public virtual string LoadText()
        {
            //read text
            return "";
        }
    }
}
