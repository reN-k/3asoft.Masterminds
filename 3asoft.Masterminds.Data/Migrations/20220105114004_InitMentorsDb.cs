using Microsoft.EntityFrameworkCore.Migrations;

namespace _3asoft.Masterminds.Data.Migrations
{
    public partial class InitMentorsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Mentors",
                columns: new[] { "Id", "Desctiption", "Name", "Profession", "Rate", "Rating" },
                values: new object[,]
                {
                    { 1, "Fugit quam distinctio iusto eum quasi error et.\nEos corporis possimus reprehenderit at a vel mollitia.", "Isobel Heller", "voluptatem", 89.077817323560737, 6.0077489847353425 },
                    { 28, "Amet ut optio in.\nVelit magni excepturi qui at placeat ab.\nEnim sit quaerat ut voluptatem et excepturi quaerat tempora.", "Ahmad Wolf", "maxime", 65.771438414962702, 6.2240906368121927 },
                    { 29, "Quibusdam repellat culpa qui beatae et qui.\nQuia atque facere ut.", "Clara Gerlach", "non", 115.2571613515062, 8.4117513934205057 },
                    { 30, "Fugiat porro in nesciunt iste perferendis earum a ut.\nRem quidem similique est delectus recusandae.\nDolorem et dolor assumenda temporibus vitae tempora fugiat ipsam.\nConsequatur nesciunt nulla reiciendis quasi eius voluptatibus.", "Izabella Bernier", "nisi", 45.354158144516006, 8.5891254658760161 },
                    { 31, "Perspiciatis quae id est.\nSit consequuntur corrupti eos corrupti fugit sed a sunt.", "Jovani Simonis", "qui", 103.16974525282613, 0.24938151251961549 },
                    { 32, "Et quas praesentium in.\nOfficia magnam dolores sed sit qui.\nRerum tempora maxime ut in.", "Alvena Nicolas", "quia", 50.092919053273704, 2.3778407100484897 },
                    { 33, "Et quaerat necessitatibus voluptatum adipisci modi excepturi temporibus voluptatibus.\nQuod ut minima.", "Yasmeen Collier", "atque", 49.660996254748198, 0.19417892684888974 },
                    { 34, "Ut recusandae ipsam et ullam quis.\nLaboriosam aut sint consequatur dolor qui deserunt.\nNeque optio omnis earum ipsam molestias ex.\nQuidem atque sed et voluptas.", "Dell Kassulke", "mollitia", 107.07176395387937, 3.5032574150260802 },
                    { 35, "Recusandae rerum accusantium quia et fuga quia nobis et adipisci.\nIn nobis quo voluptatem eveniet aspernatur velit quis a laborum.\nCum vel aspernatur eius enim est error nemo.\nCommodi magnam optio animi numquam tempore animi aperiam est.\nTempore modi dignissimos cupiditate aut.", "Kendrick Lindgren", "est", 117.09718428677748, 4.1742506316743091 },
                    { 36, "Recusandae veniam nostrum ut.\nBeatae nobis ex in sed possimus ex mollitia.\nMaiores aut quae modi.", "Gerda Morissette", "corporis", 82.860102076018279, 5.0857035466868918 },
                    { 37, "Vero nostrum quo et.\nEt quibusdam minima ut voluptatem esse.\nRerum doloremque occaecati ut suscipit.", "Jewell Hodkiewicz", "animi", 81.043550541644706, 9.4014056862338471 },
                    { 38, "Quas aliquam esse consequatur amet provident.\nNisi accusamus aperiam repellendus temporibus.\nCumque non velit a beatae commodi dolorem sunt quibusdam.\nAdipisci voluptatibus doloremque.", "Trace Lueilwitz", "laudantium", 25.590062099131785, 9.2657313026793915 },
                    { 39, "Iusto ratione eius quas autem sunt nihil aut.\nDignissimos voluptates et.\nDolores quidem consequatur ex molestias perferendis error fugiat.\nImpedit sequi modi accusantium sequi ut et a repudiandae.\nAt sequi esse omnis quo eligendi dolorem maiores expedita illum.", "Dexter Pollich", "iure", 115.39816681034777, 1.4217013779197361 },
                    { 40, "Nobis aperiam ducimus consequuntur consequatur et est odio.\nVeniam assumenda itaque.\nReprehenderit fugit provident sit iure in.", "Jettie Hermann", "consectetur", 115.08986227032256, 2.505237782609294 },
                    { 41, "Perferendis voluptas ex sapiente enim est fuga rerum recusandae et.", "Arnold Bode", "exercitationem", 84.80617336072315, 3.3936794816486908 },
                    { 42, "Velit in ab modi nihil iure qui ipsum.", "Jalen Runolfsdottir", "corrupti", 52.849376232013739, 8.073483816382236 },
                    { 43, "Aspernatur praesentium repellendus.\nVitae aut perferendis asperiores enim.", "Kendra Pacocha", "ducimus", 72.850427078386033, 3.9096188470300373 },
                    { 44, "Ad delectus est magnam.\nVoluptatibus nobis deserunt earum provident temporibus nihil aut quia explicabo.\nOmnis aliquid nam doloremque similique non doloremque.\nIn ea id nihil sapiente adipisci facere.\nNam ducimus quia in quod quia ipsum sed est adipisci.", "Petra Koelpin", "consectetur", 23.311880584206378, 2.5232675683327335 },
                    { 45, "Sint rerum porro officia officiis expedita maxime itaque.", "Ettie Lubowitz", "enim", 48.223858287941596, 8.9293162705978926 },
                    { 46, "Dolor accusamus ipsa et repellat sint quibusdam et.\nUnde aliquam quis consectetur.\nIncidunt sunt excepturi animi est quae.\nEaque suscipit autem temporibus molestiae rerum quidem.", "Belle Stark", "sed", 41.473675968625429, 2.6030580385602349 },
                    { 47, "Dignissimos ut labore eos amet sed quia provident ipsa.\nVeniam iste blanditiis officiis omnis voluptatem facilis.\nQui consectetur maxime sed dolore eos sunt.", "Donato Nader", "debitis", 69.556733163426031, 5.6666123567459223 },
                    { 48, "Animi quo temporibus qui enim praesentium sed molestiae ut.\nNostrum quia quas officiis sit voluptas molestias.\nIncidunt reiciendis voluptatibus in accusantium et sit.\nError enim a ab voluptatibus quis.", "Sebastian Crooks", "nesciunt", 73.199686697590948, 6.7027181371593469 },
                    { 27, "Labore qui vel et aperiam enim sit hic ut qui.\nFugit magni et reprehenderit incidunt ut tempora accusantium iure quis.\nOmnis ut quis cupiditate ut voluptatum sed et veniam.\nRecusandae accusamus occaecati architecto neque doloremque delectus et.\nDoloremque voluptates mollitia magni.", "Sasha Stark", "et", 60.816835810158793, 2.1322099734713369 },
                    { 26, "Sequi ut illo maiores quo ut vero at.\nEius ut provident alias quasi non reiciendis debitis quod.\nMagni aut laborum.", "Terrence Gleason", "porro", 46.539925108542633, 0.557578820994859 },
                    { 25, "Eos expedita enim nulla magnam a iusto.\nConsequatur distinctio nihil cum alias a.\nVero aut maiores et laborum assumenda quasi tempora aspernatur.", "Lavada Weissnat", "odit", 25.298367135645059, 2.4073261546005149 },
                    { 24, "Cum beatae tempora et cum sunt ut.\nPlaceat est saepe deserunt consequuntur.\nOmnis necessitatibus repellat laborum.\nQui fugiat cum quia quis non nihil odit.\nExpedita reiciendis sed nam quos quia voluptatibus fugiat.", "Johnnie Hansen", "et", 80.35299232842074, 3.7503873248353541 },
                    { 2, "Et quas asperiores.\nSaepe ipsam dolorum facere ea exercitationem expedita.", "Mallie Fay", "inventore", 32.522450598200059, 0.98678347700591362 },
                    { 3, "Distinctio assumenda et voluptatem et voluptate.\nSed omnis eaque quis quia deserunt.\nAb laborum alias.\nArchitecto a aliquid commodi et unde ex aspernatur adipisci ut.\nCumque animi sapiente inventore voluptas iusto animi sit velit.", "Mason Barrows", "saepe", 22.842262075488577, 2.6811648591799497 },
                    { 4, "Adipisci nihil rerum rerum esse necessitatibus.\nConsectetur ipsa eaque ullam.\nIpsam libero aut non modi placeat pariatur.", "Lavonne McGlynn", "sed", 53.220844531814024, 7.604273537920915 },
                    { 5, "Deserunt veniam corrupti voluptas asperiores id.\nDolorem nesciunt qui iste et consequatur vel esse.\nSit est eos beatae accusamus maxime autem autem eveniet.", "Hubert Jenkins", "voluptatem", 101.93472591337502, 5.7943596857573656 },
                    { 6, "Adipisci maiores ullam.\nCumque sed ipsa optio eos ratione molestias velit expedita deserunt.\nEaque sit rerum dolores aspernatur odio.\nNatus nulla corrupti fugit rerum.\nEligendi sint velit fugit sint quos.", "Lempi Vandervort", "ratione", 116.96739975380125, 0.4504692370307023 },
                    { 7, "Dignissimos numquam est ut vel porro corporis modi.\nConsequuntur voluptas voluptates omnis dolorum dolorem nihil qui velit.\nAliquam et alias ut hic qui saepe.\nNeque repellat cupiditate quas.\nVoluptatem quam repellat sequi quo est aut.", "Hollis Hoppe", "sint", 69.726499682444384, 0.65886151541902749 },
                    { 8, "Quod accusamus est sapiente.\nAut deleniti natus.\nDignissimos et est.\nAtque omnis eos tempora ut fuga facere deserunt ea.\nTempore qui nulla corporis amet laborum corrupti.", "Grayce Nitzsche", "dolorem", 101.55659976562326, 3.8655549724891576 },
                    { 9, "Aperiam praesentium in aspernatur omnis reprehenderit iste.\nVeritatis assumenda fuga pariatur quas.", "Chaya Windler", "beatae", 36.297899376460308, 1.5561883996968104 },
                    { 10, "Itaque vel numquam quibusdam.\nRerum ut voluptatem et optio.", "Tressie Kozey", "omnis", 28.344720273625441, 6.0971789742341169 },
                    { 11, "Et fugiat delectus et.\nOccaecati beatae soluta laboriosam aut omnis.\nVelit sapiente qui est quae dolorum expedita et.\nConsequatur illum at exercitationem eum consequatur sed.\nDeserunt sint maxime qui sed.", "Luther Harber", "aliquam", 76.898891463083629, 1.9214949812374522 },
                    { 49, "Sit repellat distinctio voluptas labore et architecto ex cumque.\nQui est itaque odio omnis qui velit nobis.\nEt saepe saepe tempora delectus ullam occaecati et exercitationem accusantium.\nOdio soluta similique vero quae reiciendis quia natus repellendus distinctio.\nVoluptatem et dolorum natus in quae non fugit expedita facere.", "Shad Kris", "tenetur", 93.512542792834594, 0.84414451888024089 },
                    { 12, "Sed hic fugiat maiores.\nNihil minus veritatis iste non delectus sed.\nDolorum nulla sit fugit est repellat voluptatem a.\nPlaceat adipisci aut sed nam et.\nEa eos et et odit corrupti vero voluptatibus et.", "Jalen Sanford", "velit", 35.20934669832203, 5.530618399163064 },
                    { 14, "Magnam aperiam voluptatem.\nUt est commodi labore mollitia quia placeat.\nQuae veritatis qui excepturi explicabo molestiae possimus expedita laboriosam nobis.\nRerum ea quibusdam perspiciatis eaque.\nVoluptatum voluptate dolor.", "Fabian Tromp", "minus", 71.829995028409172, 1.3559988706167783 },
                    { 15, "Vitae quo in officia voluptatem.", "Loma Reinger", "quae", 55.140214144690063, 2.3717177297788288 },
                    { 16, "Est vel sit eligendi similique quod cum fugit.\nAut voluptas amet.", "Elbert Herman", "non", 29.705850443945195, 8.9469916601418475 },
                    { 17, "Ad ut est.", "Bianka Runte", "delectus", 42.290450142738614, 3.2104986827869424 }
                });

            migrationBuilder.InsertData(
                table: "Mentors",
                columns: new[] { "Id", "Desctiption", "Name", "Profession", "Rate", "Rating" },
                values: new object[,]
                {
                    { 18, "Officia esse qui.\nQuo quibusdam in ullam doloremque deleniti quidem natus.", "Mariah Schumm", "earum", 26.099628855613815, 0.33768000096905976 },
                    { 19, "Quia aut necessitatibus fugit illum fugit.\nSapiente nihil excepturi facere rem nihil voluptas veritatis.\nNobis sit cupiditate veniam ut similique tenetur.", "Arjun Daniel", "reiciendis", 69.336752728063956, 2.1218544720308179 },
                    { 20, "Nemo qui fuga sed voluptatem hic optio corporis.\nUnde explicabo quo optio repellendus.\nConsequatur non ut sit distinctio.", "Effie Lind", "odio", 90.236872996965829, 8.2204237199483554 },
                    { 21, "Animi in vel in.\nCorrupti consequatur quia voluptatem nulla dolorem corporis fugit illum eum.\nAut amet magni accusamus dolorem aut provident molestias deleniti.\nVel ea reiciendis ipsa iusto aut ut et aspernatur.", "Elaina Hansen", "est", 35.795118847393951, 5.2620052337935217 },
                    { 22, "Aliquam nesciunt voluptas non ut nulla et.\nQuo alias qui necessitatibus voluptatibus officia.\nAccusamus et aut.\nAnimi incidunt voluptatibus velit sequi eaque enim porro.", "Mohamed West", "voluptatem", 34.709941688789954, 3.4982758217948842 },
                    { 23, "Possimus quis maxime unde ut ut dolores.", "Magdalena Volkman", "dolorem", 16.916119937280246, 7.8251976509695869 },
                    { 13, "Non earum repudiandae et omnis ullam velit iste impedit dolor.\nSed rerum sit odio eaque ut aliquam adipisci.", "Mya Parker", "quidem", 22.020022348696376, 7.3922689060644569 },
                    { 50, "Perspiciatis porro voluptatem omnis sit dolor magnam porro.\nBeatae reprehenderit repellendus.\nRerum eveniet modi vero officiis doloremque.\nEa eveniet voluptatum doloribus sit quis neque.", "Andreane Dooley", "eos", 105.22571409578701, 2.8872157367352469 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mentors");
        }
    }
}
