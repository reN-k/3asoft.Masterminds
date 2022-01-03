using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Interfaces;
using System;
using System.Collections.Generic;

namespace _3asoft.Masterminds.Services
{
    public class MentorService : IMentor, IShortMentor
    {
        /// <summary>
        /// Список всех менторов, пока без БД
        /// </summary>
        public static List<MentorModel> AllMentorsList = new List<MentorModel>
        {
            new MentorModel(), // для соответствия ид и номера в листе
            new MentorModel (1, "Pavlo Zibrov", "Social worker", 200.20,
                new List<string>{ "Self-control", "Flexibility", "Reliability" },
                "Etiam vitae gravida eros. Aliquam et finibus tellus. Quisque nunc arcu, interdum eget condimentum nec, varius ac enim. Curabitur nisl ligula, convallis et faucibus lacinia, lobortis nec felis. Phasellus ut ultrices dolor, varius pretium ex. Mauris a risus felis. Suspendisse tincidunt tincidunt ex ac dignissim."
                , new ReviewModel[] { new ReviewModel(10), new ReviewModel(9.5)}),
            new MentorModel (2, "Olivia Wilde",  "Psychologist", 16.41,
                 new List<string>{ "Accountability", "Competency", "Honesty" },
                 "Mauris gravida cursus vulputate. Suspendisse mi enim, luctus eu facilisis vitae, ultrices eu dui. Maecenas imperdiet orci eu hendrerit lacinia. Nam nec pulvinar leo. In congue orci quam, vitae suscipit nisl cursus sed. Mauris eget fermentum purus. Etiam tortor purus, tempor quis venenatis eget, porttitor ac nunc. Nullam sagittis sollicitudin blandit. Integer sit amet dolor ex."
                , new ReviewModel[] { new ReviewModel(5), new ReviewModel(6)}),
            new MentorModel (3, "Reese Witherspoon",  "Psychotherapist", 25.30,
                 new List<string>{ "Reliable", "Organized" },
                 "Duis eu blandit sapien, non pulvinar enim. Curabitur accumsan dapibus ultrices. Curabitur id dui at eros sodales cursus et nec justo. Nulla dignissim ex non velit consectetur tempus. Integer consectetur sem vel tempus viverra. Ut et ultricies diam. In pulvinar lorem commodo eros pulvinar efficitur. Pellentesque efficitur mi ac elit lacinia ornare. Integer sit amet blandit ex. Nullam dignissim turpis sed sodales pulvinar. Integer sagittis sed lacus ac egestas. Cras rutrum orci libero, ac posuere turpis auctor sed. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam a ex mauris."
                , new ReviewModel[] { new ReviewModel(6), new ReviewModel(5.5)}),
            new MentorModel (4, "Bruno Mars",  "Counselor", 100,
                 new List<string>{ "Accountable", "Positive attitude", "Emotional control" },
                "Proin et risus tortor. Phasellus cursus elit a rhoncus volutpat. Proin euismod sagittis rutrum. Sed imperdiet ut lacus eu sodales. Nulla dignissim placerat quam, non malesuada ligula. Sed placerat ante id lacus feugiat malesuada. Praesent gravida augue varius orci cursus, eget sollicitudin dui dictum. Sed ornare lectus non arcu cursus, a consectetur nibh vulputate. Nullam euismod erat tempor, dictum libero sed, suscipit est. Integer pellentesque malesuada mi aliquet euismod. Nam lacus justo, pellentesque vel lorem a, feugiat egestas nibh."
                , new ReviewModel[] { new ReviewModel(3), new ReviewModel(5), new ReviewModel(10)}),
            new MentorModel (5, "Gigi Hadid",  "Teacher", 59.50,
                 new List<string>{ "Focused", "Poised", "Strong communicator" },
                 "Nulla varius turpis in magna venenatis, in vestibulum orci ultricies. Aliquam erat volutpat. Nunc eu nulla hendrerit ex tempor posuere. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam id aliquam metus. Vestibulum finibus ultrices lectus. Sed volutpat gravida arcu id fringilla. Cras tincidunt, arcu eu consequat congue, nunc leo porttitor enim, vitae euismod sapien risus eget augue."
                 ),
            new MentorModel (6, "Katy Perry",  "Human resource manager", 33,
                 new List<string>{"Possesses soft skills" },
                 "Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed condimentum arcu et nisi mattis, vitae sodales massa pellentesque. Nulla hendrerit sit amet erat tristique elementum. Etiam sed est sit amet diam tristique elementum. Fusce odio lectus, eleifend sed mollis aliquet, fringilla eget sem. Fusce tincidunt eros at erat placerat, sed commodo dolor dictum. Proin quis tristique purus. Nullam posuere risus luctus magna mollis cursus. Duis iaculis massa vitae fringilla iaculis. Phasellus sodales consectetur ex vel tempor. Quisque lobortis semper dignissim. Donec eget metus leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ac nulla quis neque pretium convallis. Fusce malesuada, metus finibus congue aliquam, ex augue commodo risus, at mattis neque nunc eu elit. Quisque id volutpat tellus."
                , new ReviewModel[] { new ReviewModel(2.3), new ReviewModel(5.5), new ReviewModel(8.5)}),
            new MentorModel (7, "Natalie Portman",  "Educational psychologist", 88.88,
                 new List<string>{ "Respect for others ", "Professional image", "Competency" },
                 "Donec malesuada vehicula sapien, a venenatis orci facilisis vel. Morbi viverra lectus nisi, quis imperdiet libero sodales id. Nullam bibendum sagittis mauris. Donec non orci sodales, lacinia arcu sit amet, consectetur mi. Sed rutrum felis et placerat consectetur. Cras tristique, lorem eu commodo semper, tellus magna feugiat velit, at commodo orci tellus a sapien. Maecenas hendrerit porttitor bibendum. Integer quis varius enim. Sed erat tortor, ultricies a finibus a, suscipit eget neque. Aenean quis orci augue. Maecenas molestie laoreet nulla, ac imperdiet diam. Praesent rutrum urna eget sem porta placerat. Aliquam consequat lacus non massa rhoncus maximus."
                , new ReviewModel[] { new ReviewModel(7), new ReviewModel(9.5), new ReviewModel(5)}),
            new MentorModel (8, "Demi Moore",  "Clinical Psychologist", 200.12,
                 new List<string>{ "Honesty", "Integrity"},
                 "Sed non eros eget felis tincidunt mattis vitae in velit. Vivamus suscipit ullamcorper tempus. Donec lectus enim, viverra vitae efficitur et, laoreet a elit. Nullam vehicula est a arcu sodales egestas. Cras eget rhoncus neque, ac euismod tellus. Phasellus congue ipsum quis lobortis facilisis. Nullam neque ipsum, rhoncus vitae velit ut, fermentum luctus orci. Suspendisse et tellus tellus. Nulla eros ex, varius a enim id, eleifend malesuada lacus. Suspendisse non hendrerit tortor. Quisque sed imperdiet tortor. Cras et diam felis. Suspendisse potenti."
                , new ReviewModel[] { new ReviewModel(2.3)}),
            new MentorModel (9, "Joaquin Phoenix",  "Counselor", 32,
                 new List<string>{ "Self-control", "Accountable", "Poised" },
                 "Praesent posuere orci et justo ornare cursus. Aliquam vestibulum diam tortor, at vulputate enim aliquam in. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean efficitur tortor quis eros eleifend lobortis. Etiam tincidunt eu nunc eu facilisis. Etiam interdum, velit id sollicitudin dignissim, velit dui ornare erat, a blandit ipsum justo quis lorem. Morbi id finibus lectus. Vestibulum maximus blandit ex et varius. Pellentesque aliquam pellentesque lorem sed scelerisque. Nunc facilisis dolor id arcu aliquet vulputate."
                , new ReviewModel[] {new ReviewModel(5.5)}),
            new MentorModel (10, "Kit Harington",  "Geropsychologist", 4.20,
                 new List<string>{"Poised", "Focused" },
                 "Quisque nec vestibulum leo. Proin scelerisque augue erat, id vulputate nibh blandit sit amet. Duis molestie nisl nisl, nec pellentesque turpis consequat at. Phasellus eu eros id ante sollicitudin aliquet vel sit amet erat. Nunc interdum mauris eget est facilisis, at vestibulum ipsum fermentum. Cras at orci dui. Etiam dictum nisl id odio vulputate, et cursus dolor faucibus. Aliquam tellus massa, faucibus a blandit et, congue a velit. Proin vitae nunc id lectus tincidunt consectetur ac sed nibh. Integer id dolor justo. Cras lacus eros, gravida blandit volutpat eget, convallis vel nulla. Integer at vestibulum ante. Cras finibus ipsum non fermentum facilisis. Pellentesque tincidunt urna sed nulla facilisis, euismod cursus ipsum vestibulum. Mauris gravida leo massa, id ultrices purus aliquam ac."
                , new ReviewModel[] { new ReviewModel(8), new ReviewModel(7)}),
            new MentorModel (11, "Nicki Minaj",  "School Psychologist", 22,
                 new List<string>{ "Positive attitude", "Professional language", "Organized" },
                 "Aenean sit amet diam vel nunc malesuada maximus vel ut ligula. In ultricies mi volutpat suscipit fermentum. Curabitur eu ipsum mi. Suspendisse at imperdiet sapien. Cras in justo at ligula semper facilisis. Nunc risus nisl, bibendum sagittis odio id, tincidunt feugiat orci. Fusce ultricies magna id eleifend lobortis. Donec venenatis est vitae mauris ornare dictum. Suspendisse vel tristique magna. Etiam eget dolor orci. Ut pellentesque, risus sit amet rhoncus imperdiet, nibh est pulvinar tellus, eget aliquam nisi massa id risus. Pellentesque vel pretium neque, vitae molestie dolor. Mauris gravida in lectus ac facilisis."
                , new ReviewModel[] { new ReviewModel(2.3), new ReviewModel(5.5)}),
            new MentorModel (12, "Emma Stone",  "Sports Psychologist", 133.1,
                 new List<string>{"Ethical behavior" },
                 "Donec ipsum massa, mollis quis arcu vel, sodales lobortis metus. Duis porttitor ornare quam eget suscipit. Pellentesque sodales at lorem id euismod. Maecenas non nisi tempus, vehicula diam vel, pharetra nisi. Quisque quis sapien in sapien scelerisque maximus ac a felis. Aliquam aliquet sapien finibus, ultricies lorem nec, rhoncus ipsum. Nunc non gravida lacus. Aenean ultrices massa vitae lectus interdum ornare. Maecenas ornare gravida sem pulvinar luctus. Quisque pharetra tellus ut massa mattis interdum. Sed tincidunt suscipit dictum. Pellentesque a tempus massa, quis sagittis nulla. Morbi ornare nunc et tincidunt molestie. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos."
                 )
        };

        /// <summary>
        /// Связываем два листа ( менторы и аватары )
        /// </summary>
        public void SetAllAvatars()
        {
            AvatarService fileService = new AvatarService();

            foreach (MentorModel mentor in AllMentorsList)
            {
                mentor.SetAvatar(AvatarService.MentorAvatarsList[mentor.Id]);
            }
        }

        /// <summary>
        /// Получение списка короткого описания всех менторов
        /// </summary>
        /// <returns>Список короткого описания всех менторов</returns>
        public List<ShortDescriptionMentorModel> GetAllMentorsShortInfo()
        {
            List<ShortDescriptionMentorModel> shortDescriptionMentors = new List<ShortDescriptionMentorModel>();

            foreach (MentorModel m in AllMentorsList)
            {
                shortDescriptionMentors.Add(new ShortDescriptionMentorModel(m.Id, m.Avatar, m.Name,
                    m.Profession, m.Rating));

                //shortDescriptionMentors.Add(new ShortDescriptionMentorModel(m.Id, m.Photo, m.Name, 
                //    m.Profession, m.Rating));
            }

            return shortDescriptionMentors;
        }

        /// <summary>
        /// Получение профиля ментора с определённым id
        /// </summary>
        /// <param name="_id">Id ментора в списке</param>
        /// <returns>Профиль менторв</returns>
        /// <exception cref="NotImplementedException">Ошибка при неверном id</exception>
        public MentorModel GetMentorProfile(int _id)
        {
            if (_id > AllMentorsList.Count || _id <= 0)
            {
                throw new Exception("Wrong id");
            }

            return AllMentorsList[_id];
        }
    }
}
