namespace Pomelo.EntityFrameworkCore.Lolita.Update
{
    public class SetFieldInfo
    {
        public string Field { get; set; }

        public string Type { get; set; }

        public object Value { get; set; }

        public int Index { get; set; }
    }
}