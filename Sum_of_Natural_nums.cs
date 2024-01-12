class Sum_of_Natural_nums
{
static void Main (string[] args ){
Console.WriteLine("Sum of natural nums. Enter int, please (>0)");
string s = Console.ReadLine();
int n = Convert.ToInt32(s);
if (n<1){Console.WriteLine("err");}
Console.WriteLine("Good! n is: "+n);
Console.WriteLine("Sum of natural nums by 0.5*n*(n+1) is: "+ 0.5*n*(n+1));
int i=0;
int sum=0;
while (n!=0){sum+=n; n--; i++;}
Console.WriteLine("Sum of natural nums by cycle is: "+ sum +" with "+i+" iterations");
Console.WriteLine("by OlegTim. Press 'Enter' to quit "); Console.Read();
}
}