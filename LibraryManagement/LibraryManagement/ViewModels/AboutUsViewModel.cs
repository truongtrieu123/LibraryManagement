using LibraryManagement.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class AboutUsViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public BindingList<Member> Members { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định đối tượng
        /// </summary>
        public AboutUsViewModel(MainViewModel param)
        {
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            Members = MemberListViewModel.MemberList();
        }

    }

    public class MemberListViewModel
    {
        public static BindingList<Member> Members { get; set; }

        public static BindingList<Member> MemberList()
        {
            Members = new BindingList<Member>();

            var member1 = new Member
            {
                Name = "Trương Đại Triều",
                AvatarImage = "/Data/Images/Background/0096.png",
                Job = "Student",
                Position = "Designer & Developer",
                Gmail = "truongdaitrieu2109@gmail.com",
                Facebook = "truong.daitrieu.5"
            };

            var member2 = new Member
            {
                Name = "Lê Văn Trung",
                AvatarImage = "/Data/Images/Background/0622.jpg",
                Job = "Student",
                Position = "Designer & Deverloper",
                Gmail = "letrung@gmail.com",
                Facebook = "Lê Văn Trung"
            };
            Members.Add(member1);
            Members.Add(member2);

            return Members;
        }
    }

    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AvatarImage { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        public string Gmail { get; set; }
        public string Facebook { get; set; }

        public Member()
        {

        }
    }
}
