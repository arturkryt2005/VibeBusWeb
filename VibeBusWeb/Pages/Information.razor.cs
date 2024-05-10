namespace VibeBusWeb.Pages;

public partial class Information
{
    public class City
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }

    private List<City> Cities = new()
    {
        new City { Name = "Агрыз", ImageUrl = "https://avatars.mds.yandex.net/get-altay/6203703/2a0000017fb04255a46bb5aabed5bbf73aa6/XXXL" },
        new City { Name = "Уфа", ImageUrl = "https://avatars.mds.yandex.net/get-altay/9114271/2a0000018ddad2553c03ae82df2f88fd0cbb/XXXL" },
        new City { Name = "Казань", ImageUrl = "https://avatars.mds.yandex.net/get-altay/4797538/2a0000017983956b85d0b2afc04595bd5d96/XXXL" },
        new City { Name = "Москва", ImageUrl = "https://avatars.mds.yandex.net/get-altay/11420721/2a0000018e60eaa39a21ce6d02b84691b12d/XXXL" },
        new City { Name = "Екатеринбург", ImageUrl = "https://avatars.mds.yandex.net/get-altay/2812564/2a00000174cd392f1bd7a6844bf24acebdfe/XXXL" },
        new City { Name = "Н. Новгород", ImageUrl = "https://avatars.mds.yandex.net/get-altay/1349040/2a0000016314748922effe135f7430c93c09/XXXL" },
        new City { Name = "Самара", ImageUrl = "https://avatars.mds.yandex.net/get-altay/1880524/2a0000016e83104f286b0074f65c147f6fc4/XXXL" },
        new City { Name = "Омск", ImageUrl = "https://avatars.mds.yandex.net/get-altay/1881820/2a0000016afa090d003820a98138063dd077/XXXL" }
    };
}