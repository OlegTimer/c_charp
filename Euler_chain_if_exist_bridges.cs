using System;
using System.IO;
using System.Text;
/*
using System;
using System.IO;
using System.Text;
linqpad: move 'using' directives to query prosperities? (if y, compliles fine)
*/
class Euler_chain_if_exist_bridges
{
static void Main (string[] args ){
Console.WriteLine("_ Euler chain if exist (the Konigsberg bridges problem) _ \r\n"); 
Console.WriteLine("There are some areas, connected with bridges across the river.");
Console.WriteLine("Is it possible to cross ALL bridges and each bridge meet only once? \r\n"); 

Console.WriteLine("To enter data, please fill _input.txt in the program's directory");
Console.WriteLine("At first name all areas (in mind or on paper, etc) starting from 0. ");
Console.WriteLine("First line in _input.txt is empty.");
Console.WriteLine("After enter info to file for all bridges, each from new line:");
Console.WriteLine("Write name of area from one side of bridge <SPACE> other area name \r\n");
Console.WriteLine("For example, area 0 is connected with area 1 ; area 1 is connected with area 2");
Console.WriteLine("0 - 1 - 2");
Console.WriteLine("As you see, there are 2 bridges (0-1 and 1-2). Enter 1+2 lines to _input.txt");
Console.WriteLine("\r\n0\t1");
Console.WriteLine("1\t2");
Console.WriteLine("After providing correct information, run the program again.");

List<int> list = new List<int>(); 
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
int err=0;

FileStream fRead = new FileStream("_input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
byte[] readArr = new byte[1024];
int count;
while ((count = fRead.Read(readArr, 0, readArr.Length)) > 0) {
string s= Encoding.UTF8.GetString(readArr, 0, count);
char[] dividers = { ' ' , '\r','\n' } ;
string[] seg = s.Split(dividers);
foreach(string i in seg){
int i0=-1; 
try {i0 = Convert.ToInt32(i);} catch(Exception e){}
if (i0!=-1){list.Add(i0);}
}
}
fRead.Close();

int t=0;
int i1=-1;
int i2=-1;
foreach(int i in list){
if (t%2==0){i1=i;}else{
i2=i;
if (i1<i2){list1.Add(i1); list2.Add(i2);}else{list1.Add(i2); list2.Add(i1);}
if (i1<0 || i2<0 || i1==i2){err++;}
//Console.WriteLine(i1+" "+i2);
}
t++;
}

if (list1.Count != list2.Count || list1.Count<1){err++;}

if (err!=0){Console.WriteLine("\r\n\r\nERROR in _input.txt\r\n\r\n");}else{
Console.WriteLine("...Seems _input.txt is fine...\r\n\r\n");}

int[] arr = new int[list1.Count+1]; //areas not more than n+1 bridges
for(int i = 0; i<list1.Count+1; i++){arr[i]=0; }
list1.Sort();
list2.Sort();
foreach(int i in list1){arr[i]++;}
foreach(int i in list2){arr[i]++;}
Console.WriteLine("Let's count number of bridges to all areas:");
int odd=0;
foreach(int i in arr){if (i!=0){
if (i%2!=0){odd++;}
Console.WriteLine("Number of bridges to this area is: "+i);
}}

if (odd==0 || odd==2){
Console.WriteLine("It's possible to cross all bridges, meeting each bridge only once");
}
else{
Console.WriteLine("It's NOT possible to cross all bridges, meeting each bridge only once");
Console.WriteLine("The volume of areas with odd number of bridges is not 0 or 2");
}

Console.WriteLine("\r\nby OlegTim. Press 'Enter' to quit "); Console.Read();
}
}
/*
Different ways of info representation:

Description in natural language (part):
Maybe you can travel from Richmond via London_bridge to Dagenham.

Draw named areas and bridges (one example):
C
~|c|~|d|~|g|~~
~      ~     ~
~      -     ~
~   A  e  D  ~ 
~      -     ~
~      ~     ~
~|a|~|b|~|f|~~
B

Blind (no-names) drawing:
~||~||~~~||~~
~      ~    ~
~      =    ~
~      ~    ~
~||~||~~~||~~

Describe all ways with named areas (A,B...) through bridges (a,b...):
AaB AbB AcC AdC AeD
BaA BbA BfD
CcA CdA CgD
DeA DfB DgC

Describe all ways with named areas only (it's a problem which bridge):
AB AB AC AC AD
BA BA BD
CA CA CD
DA DB DC

Describe all ways with bridges in order (first line is a bridge 'a', etc):
A	B
A	B
A	C
A	C
A	D
B	D
C	D

Areas in bridge list can be named with integers (A=0;B=1; etc):
0	1
0	1
0	2
0	2
0	3
1	3
2	3
*/