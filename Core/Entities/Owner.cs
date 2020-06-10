namespace Core.Entities
{
    public class Owner : EntityBase
    {

        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string profile { get; set; }
        public Address address { get; set; }
    }
}
