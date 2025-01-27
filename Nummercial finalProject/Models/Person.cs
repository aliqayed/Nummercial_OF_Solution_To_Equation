
namespace Nummercial_finalProject.Models
{
    public enum Stages
    {
        [Display(Name = "School Stages")]
        School_Stages,

        [Display(Name = "Educational Stages")]
        Educational_Stages,

        [Display(Name = "University Stages")]
        University_Stages,

        [Display(Name = "Professional Stages")]
        Professional_Stages
    }

    public enum Governments
    {
        [Display(Name = "Cairo Governorate")]
        Cairo,

        [Display(Name = "Giza Governorate")]
        Giza,

        [Display(Name = "Alexandria Governorate")]
        Alexandria,

        [Display(Name = "Assiut Governorate")]
        Assiut,

        [Display(Name = "Aswan Governorate")]
        Aswan,

        [Display(Name = "Beni Suef Governorate")]
        BeniSuef,

        [Display(Name = "Beheira Governorate")]
        Beheira,

        [Display(Name = "Dakahlia Governorate")]
        Dakahlia,

        [Display(Name = "Damietta Governorate")]
        Damietta,

        [Display(Name = "Faiyum Governorate")]
        Faiyum,

        [Display(Name = "Gharbia Governorate")]
        Gharbia,

        [Display(Name = "Ismailia Governorate")]
        Ismailia,

        [Display(Name = "Kafr El Sheikh Governorate")]
        KafrElSheikh,

        [Display(Name = "Luxor Governorate")]
        Luxor,

        [Display(Name = "Matrouh Governorate")]
        Matrouh,

        [Display(Name = "Minya Governorate")]
        Minya,

        [Display(Name = "Monufia Governorate")]
        Monufia,

        [Display(Name = "New Valley Governorate")]
        NewValley,

        [Display(Name = "North Sinai Governorate")]
        NorthSinai,

        [Display(Name = "Port Said Governorate")]
        PortSaid,

        [Display(Name = "Qalyubia Governorate")]
        Qalyubia,

        [Display(Name = "Qena Governorate")]
        Qena,

        [Display(Name = "Red Sea Governorate")]
        RedSea,

        [Display(Name = "Sharqia Governorate")]
        Sharqia,

        [Display(Name = "Sohag Governorate")]
        Sohag,

        [Display(Name = "South Sinai Governorate")]
        SouthSinai,

        [Display(Name = "Suez Governorate")]
        Suez
    }

    public class Person
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [MaxLength(20)]
        [RegularExpression(@"^\+20\d{11}$", ErrorMessage = "Invalid phone number format.")]
        public string Telephone { get; set; } = string.Empty;

        [Required]
        public Stages Stage { get; set; }


        public List<string> LocalGovernments { get; set; } = new();

        public string LGovermentsSerialized
        {
            get => string.Join(",", LocalGovernments);
            set => LocalGovernments = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public string Note { get; set; } = string.Empty;



        // Navigation property for Problems
        public virtual ICollection<Problem>? Problems { get; set; }
        public virtual ICollection<ProblemR>? ProblemsR { get; set; }



    }



}

