namespace MyMauiApp.Models
{
    public class UserModel : BaseModel
    {        
        private string login;
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

		private string password;
		public string Password
		{
			get => password;
			set => SetProperty(ref password, value);
		}

        //public void test()
        //{
        //    var tripmodel = new TripModel(DateTime.Now, "Porto Vecchio");
        //    //tripmodel.Id;
        //}
	}
}
