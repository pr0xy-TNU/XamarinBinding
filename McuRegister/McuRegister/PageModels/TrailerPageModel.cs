using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using McuRegister.Enums;
using McuRegister.Models;

namespace McuRegister.PageModels
{
    public class TrailerPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public TrailerModel Trailer { get; set; }

        public TrailerListPageModel tlp;

        #region Properties 
        public string Id
        {
            get
            {
                return Trailer.Id;
            }
            set
            {
                if (Trailer.Id != value)
                {
                    Trailer.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string LandmarkSerialNumber
        {
            get
            {
                return Trailer.LandmarkSerialNumber;
            }
            set
            {
                if (Trailer.LandmarkSerialNumber != value)
                {
                    Trailer.LandmarkSerialNumber = value;
                    OnPropertyChanged("LandmarkSerialNumber");
                }
            }
        }
        public string McuSerialNumber
        {
            get
            {
                return Trailer.McuSerialNumber;
            }
            set
            {
                if (Trailer.McuSerialNumber != value)
                {
                    Trailer.McuSerialNumber = value;
                    OnPropertyChanged("McuSerialNumber");
                }
            }
        }

        public string Company
        {
            get
            {
                return Trailer.Company;
            }
            set
            {
                if (Trailer.Company != value)
                {
                    Trailer.Company = value;
                    OnPropertyChanged("Company");
                }
            }
        }

        #endregion

        public TrailerListPageModel ListPageModel
        {
            get
            {
                return tlp;
            }
            set
            {
                if (tlp != value)
                {
                    tlp = value;
                    OnPropertyChanged("ListPageModel");
                }
            }
        }

        public TrailerPageModel()
        {
            Trailer = GenarateTrailerModel();
        }
        public TrailerPageModel(TrailerModel model)
        {
            Trailer = model;
        }

        #region Trailer random genarator
        static public TrailerModel GenarateTrailerModel()
        {
            TrailerModel temp = new TrailerModel();
            temp.Company = GetCompanyName();
            temp.Id = GenarateValue(SerialType.ID);
            temp.McuSerialNumber = GenarateValue(SerialType.MCU);
            temp.LandmarkSerialNumber = GenarateValue(SerialType.LANDMARK);
            return temp;
        }

        static public String GenarateValue(SerialType type)
        {
            Random random = new Random();
            StringBuilder serialNumber = new StringBuilder();
            switch (type)
            {
                case SerialType.MCU:
                    serialNumber.Append("MCU");
                    break;
                case SerialType.TRAILER:
                    serialNumber.Append("TRAILER");
                    break;
                case SerialType.LANDMARK:
                    serialNumber.Append("LM");
                    break;
                case SerialType.ID:
                    break;
                default:
                    return "UNKNOW";
            }
            serialNumber.Append(random.Next(1000000).ToString());
            return serialNumber.ToString();
        }

        static public string GetCompanyName()
        {
            Random random = new Random();
            string[] companies = new string[]
            {
                "Openlane",
                "Yearin",
                "Goodsilron",
                "Condax",
                "Opentech",
                "Golddex",
                "year-job",
                "Isdom",
                "Gogozoom",
                "Y-corporation",
                "Nam-zim",
                "Donquadtech",
                "Warephase",
                "Donware",
                "Faxquote",
                "Sunnamplex",
                "Lexiqvolax",
                "Sumace",
                "Treequote"
            };
            return companies[random.Next(companies.Length - 1)];
        }
        #endregion

        public bool IsValid
        {
            get
            {
                return
                     (!string.IsNullOrEmpty(Id.Trim())) ||
                     (!string.IsNullOrEmpty(McuSerialNumber.Trim())) ||
                     (!string.IsNullOrEmpty(Company.Trim())) ||
                     (!string.IsNullOrEmpty(LandmarkSerialNumber.Trim()));
            }
        }

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
