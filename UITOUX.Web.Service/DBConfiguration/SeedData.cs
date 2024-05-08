namespace UITOUX.Web.Service.DBConfiguration
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.SaveChanges();
        }
    }
}
