
namespace TShapedFoundation.DataObjects
{
    public class CustomerRegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateIndex { get; set; }
        public string Postcode { get; set; }
        public string MobilePhone { get; set; }
        public string EmailName { get; set; }
        public string EamilAddressName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}
