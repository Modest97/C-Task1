using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LNU.AMI33.Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileArr = File.ReadAllLines("../../input.txt");
            Student[] students = new Student[fileArr.Length];
            int idNum = 1;
            for (int i = 0; i < fileArr.Length; ++i)
            {
                string[] lineArr = fileArr[i].Split(' ');
                students[i] =new Student(lineArr[0],int.Parse(lineArr[1]) ,new Person(lineArr[2],int.Parse(lineArr[3])) );
               students[i].Id = idNum;
                idNum++;
            }
            StreamWriter file = new StreamWriter("../../output.txt");
            //foreach (var i in students)
            //{
            //    i.Print( file);
            //}
            

           
        


            var selectTeachers = from t in students       
                                select t.Curator;

            Teacher[] teachers = new Teacher[selectTeachers.LongCount()];
           List<Teacher> teach= teachers.ToList();
            foreach (var elem in selectTeachers)
            {
                List<Student> studList = new List<Student>();
                for (int i = 0;i<students.LongCount();++i)
                {
                    if(students[i].Curator.Equals(elem))
                    {
                        studList.Add(students[i]);
                    }
                }
                teach.Add(new Teacher(elem, studList));

            }
            teachers = teach.ToArray();
            for (int i = 0; i < teachers.LongCount(); ++i)
            {
                if (teachers[i] !=null)
                teachers[i].Id = idNum;
                idNum++;
            }
          
            //foreach (var i in teachers)
            //{
            //    if(i!=null)
            //    i.Print(file);
            //}

          
            //2
            Student[] studentsClone = new Student[students.Length ];
            studentsClone = (Student[])students.Clone() ;
            Teacher[] teachersClone = new Teacher[teachers.Length];
            teachersClone = (Teacher[])teachers.Clone();
            foreach (var i in teachersClone)
            {
                if (i != null)
                    i.Print(file);
            }
            foreach (var i in studentsClone)
            {
                if (i != null)
                    i.Print(file);
            }
            file.Close();
            Console.ReadKey();
        }
    }
    public  class Person
    {
        private string name;
        private int age;
        private int id;
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public Person(string _name,int _age)
        {
            name = _name;
            age = _age;
        }
       public Person(Person _person)
        {
            name = _person.name;
            age = _person.age;
        }


        public override int GetHashCode()
        {
            return id;
        }
        public override string ToString()
        {
            string person;
            person = name + "  " + age.ToString() + " years ";
            return person;
        }

    }
    public class Student : Person
    {
        Person curator;
        public Student(string _name,int _age,Person _curator):base(_name,_age)
        {
            curator = _curator;
        }
     public Person Curator
        {
            get
            {
                return (curator);
            }
        }
        public  void Print(StreamWriter _file)
        {
          
            _file.Write(this.ToString());
            
         
        }
        public override string ToString()
        {
            string student;
            student = base.ToString() + "\n  curator: " + curator.ToString()+ "\n";
            return student;
        }
        public override bool Equals(object stud_2)
        {

            return base.Equals(stud_2);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class Teacher : Person
    {
        List<Student> students;
       public Teacher(Person _teacher , List<Student> _students):base(_teacher)
        {
            students = _students;
        }
        public void Print(StreamWriter file)
        {
           

            file.Write(this.ToString());

          
        }
        public override string ToString()
        {
            string teacher;
            teacher = base.ToString()+"\n";
            foreach(var i in students)
            {
                teacher += "\n" + i.ToString();
            }
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
