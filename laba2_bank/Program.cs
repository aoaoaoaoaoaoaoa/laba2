using System;
using System.Diagnostics;
using bibls;



namespace laba2
{
     enum part_money:int{
            first,//3000
            second,// = 5000,
            three,//10000,
            four//15000


        }
    
    class iner:INTER{
        vip_account<Guid> user_vip;
        bank_account<Guid> user;
        bool vip_turn = false;
        bool base_turn = false;
        public void Start(){
            System.Console.WriteLine("1.Создать аккаунт\n2.Создать вип аккаунт\n3.закрыть");
            int create;
            while(true){
                create = Convert.ToInt32(Console.ReadLine());
                switch(create){
                    case 1: create_account(); break;
                    case 2: create_vip_account(); break;
                    case 3: Environment.Exit(0); break;
                    default: System.Console.WriteLine("error input data, try again "); break;
                            

                    
                };
                break;
            }
            int create1;
            bool ok = true;

            while(ok){
                System.Console.WriteLine("1.Показать информацию по счету\n2.Показать все накоплени\n3.показать проценты\n4.показать бонус\n5.Сделать аккаунт вип\n6.удалить аккаунт\n7.exit");
                create1 = Convert.ToInt32(Console.ReadLine());
                switch(create1){
                    case 1: show_info();break;
                    case 2: show_total_sum(); break;
                    case 3: show_total_proccents(); break;
                    case 4: show_total_bonus(); break;
                    case 5: create_vip_account(); break;
                    case 6: delete_account(); break;
                    case 7: Environment.Exit(0); break;
                    default: System.Console.WriteLine("error imput datas"); break;
                    

                };

            }





        }
        public void create_account(){
            base_turn = true;
            Guid ID = Guid.NewGuid();
            int[] mass={3000,5000,10000,15000};
            double[] mass1={0.03,0.05,0.1,0.15};
            System.Console.WriteLine("Выберите тариф:");
            for(int i = 0; i<4; i++){
                System.Console.WriteLine($"{i+1}. взнос: {mass[i]}, процент за месяц {mass1[i]}");

            }
            int decision = Convert.ToInt32(Console.ReadLine());

            user = new bank_account<Guid>(ID, decision);

        }
        public void create_vip_account(){
            if(vip_turn == true){
                System.Console.WriteLine("errors");
            }
            else{
                vip_turn = true;
                base_turn = false;
                Guid ID = Guid.NewGuid();
                int[] mass={3000,5000,10000,15000};
                double[] mass1={0.03,0.05,0.1,0.15};
                System.Console.WriteLine("Выберите тариф:");
                for(int i = 0; i<4; i++){
                    System.Console.WriteLine($"{i+1}. взнос: {mass[i]}, процент за месяц {mass1[i]}");

                }
                int decision = Convert.ToInt32(Console.ReadLine());

                user_vip = new vip_account<Guid>(ID, decision);
            }

        }
        public void delete_account(){
            GC.Collect();
            
        }
        public void show_info(){
            if(base_turn){
                user.information_account();
            }
            else if(vip_turn){
                user_vip.information_account();
            }
        }
        public void show_total_sum(){
            if(base_turn){
                user.end_sum();
            }
            else if(vip_turn){
                user_vip.end_sum();
            }
            
        }
        public void show_total_proccents(){
             if(base_turn){
                user.procents();
            }
            else if(vip_turn){
                user_vip.procents();
            }

        }
        public void show_total_bonus(){
            if(base_turn){
                user.year_count();
            }
            else if(vip_turn){
                user_vip.year_count();
            }
        }

    

    }





    class Data{
    
        public int days{
            get;
            set;
        }
        public int months{
            get;
            set;
        }
        public int years{
            get;
            set;
        }
        public Data(){
            DateTime tmp = new DateTime();
            tmp = DateTime.Now;
            string str;
            str = tmp.ToShortDateString();
            days = Convert.ToInt32(str.Substring(0,2));
            months = Convert.ToInt32(str.Substring(3,2));
            years = Convert.ToInt32(str.Substring(6,4));
            

            
        }
        public Data(Data other){
            this.days = other.days;
            this.months = other.months;
            this.years = other.years;
            

            
        }
        public Data(int day, int month, int year){
            days = day;
            months = month;
            years = year;
            

            
        }

        public int count_month(Data date){
                return (date.years - this.years)*12 + (date.months - this.months);

        }
        public int count_year(Data date){
                return (date.years - this.years);

        }
        public void ADD_D(){
            if(days ==31 && (months == 1 | months == 3 | months == 5 | months == 7 | months ==8 | months ==10 | months ==12)){
                days = 1;
                ADD_M();
            }
            else if(days ==30 && (months == 4 | months == 6 | months == 9 | months == 11)){
                days = 1;
                ADD_M();
            }
            else{
                days+=1;
            }
            

        }
        public void ADD_M(){
            if(months == 12){
                months = 1;
                ADD_Y();
            }
            else{
                months+=1;
            }

        }
        public void ADD_Y(){
            years+=1;
        }
        public bool equal(Data other){
            if(this.days == other.days && this.months == other.months && this.years == other.years){
                return true;
            }
            else{

                return false;
            }
        }
    }



    class ___main
    {

        static void Main(){
            iner a = new iner();
            a.Start();

        
        
    
            
            


        }
    }

    abstract class account<T>
    {

        public T id{
            get;
            set;
        }
        public Data data{
            get;
            set;
        }
        public abstract void accessibly_money();
        virtual public void information_account(){
            Console.WriteLine($"id: {id}\nДата заведения счета: {data.days}:{data.months}:{data.years}");

        }


    

    }

    class bank_account<T>:account<T>
    {
        protected double suma{
            get;
            set;
        }
        protected double  part{
            get;
            set;
        }
        protected double bonus;
        protected Data nDate;
        double [] procent = {0.03, 0.05 ,0.1, 0.15};
       
        protected part_money stavka;
        public bank_account(T ID, int key){
        
            id = ID;
            bonus = 0.001;
            data = new Data();
            key -= 1;
            part = procent[key];
            stavka = (part_money)key;
            suma = stavka switch{
                part_money.first=>3000,
                part_money.second=>5000,
                part_money.three=>10000,
                part_money.four=>15000,
                _ => throw new Exception("Неизвестное действие")
            };
            

        
            
        }
        ~bank_account(){

        }
        virtual public double end_sum(){
            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
            double  tmp = suma;
            int tmp2 = 0;
            
        
        
            nDate = new Data(d,m,y);
            tmp2 = data.count_month(nDate);
            for(int i= 1; i<=tmp2; i++){
                if(i%12 == 0){
                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                
                    tmp+=tmp*part;


                }
            }

        

        Console.WriteLine($"Всего накоплений: {tmp}");
        return tmp;
            
        }

        virtual public double procents(){
            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
        
            double  tmp = suma;
            double rezult = 0;
            int tmp2 = 0;
            
        
        
            nDate = new Data(d,m,y);
            tmp2 = data.count_month(nDate);
            for(int i= 1; i<=tmp2; i++){
                if(i%12 == 0){
                    rezult+=tmp*part;
                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                    rezult+=tmp*part;
                    tmp+=tmp*part;

                }
            }


        

        Console.WriteLine($"накоплений с процентной ставки: {rezult}");
        return rezult;
            
        }





        virtual public double year_count(){
            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
        
            double  tmp = suma;
            double rezult = 0;
            int tmp2 = 0;
            
        
        
            nDate = new Data(d,m,y);
            tmp2 = data.count_month(nDate);
            for(int i= 1; i<=tmp2; i++){
                if(i%12 == 0){
                    rezult+=tmp*bonus;
                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                    tmp+=tmp*part;

                }
            }


        

        Console.WriteLine($"накоплений с бонусов : {rezult}");
        return rezult;
            
        }




        public override void accessibly_money(){
            Console.WriteLine($"Доступно средств для снятия:{suma}");

        }
            
    


    }
    class vip_account<T>:bank_account<T>{
        double money{set; get;}
        



        public vip_account(T ID, int key):base(ID,key){
            money = stavka switch{
                part_money.first=>3000,
                part_money.second=>5000,
                part_money.three=>10000,
                part_money.four=>15000,
                _ => throw new Exception("Неизвестное действие")
            };
            bonus = 0.003;

        }
        ~vip_account(){
            
        }

        override public double end_sum(){
            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
            
            double  tmp = suma;
            int tmp2 = 0;
            
        
            
            nDate = new Data(d,m,y);
            tmp2 = data.count_month(nDate);
            
            for(int i= 1; i<=tmp2; i++){
                if(i%12 == 0){
                    tmp += money;
                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                    tmp += money;
                
                    tmp+=tmp*part;

                }
            }

        

        Console.WriteLine($"накоплений с процентной ставки: {tmp}");
        return tmp;
            
        }
        override public double procents(){
            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
        
            double  tmp = suma;
            double rezult = 0;
            int tmp2 = 0;
            
        
        
            nDate = new Data(d,m,y);
            tmp2 = data.count_month(nDate);
            for(int i= 1; i<=tmp2; i++){
                if(i%12 == 0){
                    tmp += money;
                    rezult+=tmp*part;
                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                    tmp += money;
                    rezult+=tmp*part;
                    tmp+=tmp*part;

                }
            }


        

        Console.WriteLine($"накоплений с процентной ставки: {rezult}");
        return rezult;
            
        }





        override public double year_count(){
            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
            
        
            double  tmp = suma;
            double rezult = 0;
            int tmp2 = 0;
            
        
            nDate = new Data(d,m,y);
            tmp2 = data.count_month(nDate);
            for(int i= 1; i<=tmp2; i++){
                if(i%12 == 0){
                    tmp += money;
                    rezult+=tmp*bonus;
                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                    tmp += money;
                    tmp+=tmp*part;

                }
            }


        

        Console.WriteLine($"накоплений с бонусов : {rezult}");
        return rezult;
            
        }




        override public void information_account(){
            double  tmp = suma;
            double rezult = 0;
            double rezult_bonus = 0;
            int tmp2 = 0;
            Console.WriteLine($"id: {id}\nДата заведения счета: {data.days}:{data.months}:{data.years}\n");


            Console.WriteLine("Введите дату, на момент который хотите посмотреть накопленные деньги по выбранному вами тарифу\nday: ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("year: ");
            int y = Convert.ToInt32(Console.ReadLine());
            nDate = new Data(d,m,y);
            Data mDate = new Data(data);
            int i = mDate.months;

            while(!(mDate.equal(nDate))){
                
                if(i%12 == 0){
                    tmp += money;
                    rezult_bonus+=tmp*bonus;
                    rezult +=tmp*part;

                    tmp+=tmp*part;
                    tmp+=tmp*bonus;
                }
                else{
                    tmp += money;
                    tmp+=tmp*part;

                }
                Console.WriteLine($"Дата: {mDate.days}:{data.months}:{data.years}  сумма={tmp}   проценты{rezult} годовой бонус={rezult_bonus}");
                mDate.ADD_M();
                i++;
            }   



        


        }
        

    }



}
