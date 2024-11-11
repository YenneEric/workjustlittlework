namespace PersonData.Models
{
    public class AddressType
    {
        public int AddressTypeId { get; }
        public string Name { get; }

        public AddressType(int addressTypeId, string name)
        {
            AddressTypeId = addressTypeId;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
