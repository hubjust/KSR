using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database
{
    [Table(Name = "FIFA19PlayerDB")]
    public partial class FifaPlayer
    {
        private string club;
        private string league;
        private string nationality;
        private string position;
        private int age;
        private int height;
        private int weight;
        private int pace;
        private int acceleration;
        private int sprintSpeed;
        private int dribbling;
        private int agility;
        private int  balance;
        private int reactions;
        private int ballControl;
        private int composure;
        private int shooting;
        private int positioning;

        [Column(Name = "Club")]
        public string Club
        {
            get
            {
                return club;
            }
            set
            {
                if ((this.club != value))
                {
                    this.club = value;
                }
            }
        }

        [Column(Name = "League")]
        public string League
        {
            get
            {
                return league;
            }
            set
            {
                if ((this.league != value))
                {
                    this.league = value;
                }
            }
        }

        [Column(Name = "Nationality")]
        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                if ((this.nationality != value))
                {
                    this.nationality = value;
                }
            }
        }

        [Column(Name = "Position")]
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                if ((this.position != value))
                {
                    this.position = value;
                }
            }
        }

        [Column(Name = "Age")]
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if ((this.age != value))
                {
                    this.age = value;
                }
            }
        }

        [Column(Name = "Height (cm)")]
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if ((this.height != value))
                {
                    this.height = value;
                }
            }
        }

        [Column(Name = "Weight (cm)")]
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if ((this.weight != value))
                {
                    this.weight = value;
                }
            }
        }

        [Column(Name = "Pace")]
        public int Pace
        {
            get
            {
                return pace;
            }
            set
            {
                if ((this.pace != value))
                {
                    this.pace = value;
                }
            }
        }

        [Column(Name = "Acceleration")]
        public int Acceleration
        {
            get
            {
                return acceleration;
            }
            set
            {
                if ((this.acceleration != value))
                {
                    this.acceleration = value;
                }
            }
        }

        [Column(Name = "Sprint Speed")]
        public int SprintSpeed
        {
            get
            {
                return sprintSpeed;
            }
            set
            {
                if ((this.sprintSpeed != value))
                {
                    this.sprintSpeed = value;
                }
            }
        }

        [Column(Name = "Dribling")]
        public int Dribbling
        {
            get
            {
                return dribbling;
            }
            set
            {
                if ((this.dribbling != value))
                {
                    this.dribbling = value;
                }
            }
        }

        [Column(Name = "Agility")]
        public int Agility
        {
            get
            {
                return agility;
            }
            set
            {
                if ((this.agility != value))
                {
                    this.agility = value;
                }
            }
        }

        [Column(Name = "Balance")]
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if ((this.balance != value))
                {
                    this.balance = value;
                }
            }
        }

        [Column(Name = "Reactions")]
        public int Reactions
        {
            get
            {
                return reactions;
            }
            set
            {
                if ((this.reactions != value))
                {
                    this.reactions = value;
                }
            }
        }

        [Column(Name = "Ball Control")]
        public int BallControl
        {
            get
            {
                return ballControl;
            }
            set
            {
                if ((this.ballControl != value))
                {
                    this.ballControl = value;
                }
            }
        }

        [Column(Name = "Composure")]
        public int Composure
        {
            get
            {
                return composure;
            }
            set
            {
                if ((this.composure != value))
                {
                    this.composure = value;
                }
            }
        }

        [Column(Name = "Shooting")]
        public int Shooting
        {
            get
            {
                return shooting;
            }
            set
            {
                if ((this.shooting != value))
                {
                    this.shooting = value;
                }
            }
        }

        [Column(Name = "Positioning")]
        public int Positioning
        {
            get
            {
                return positioning;
            }
            set
            {
                if ((this.positioning != value))
                {
                    this.positioning = value;
                }
            }
        }

    }
}
