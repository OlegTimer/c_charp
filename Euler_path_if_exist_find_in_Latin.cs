using System;
using System.IO;
using System.Text;
/*
using System;
using System.IO;
using System.Text;
linqpad: move 'using' directives to query prosperities? (if y, compliles fine)
*/
class Euler_path_if_exist_find_in_Latin
{
static void Main (string[] args ){
Console.WriteLine("_ Euler_path_if_exist_find_in_Latin (the Konigsberg bridges problem) _ \r\n"); 
Console.WriteLine("There are some areas, connected with bridges across the river.");
Console.WriteLine("Is it possible to cross ALL bridges and each bridge meet only once? \r\n"); 

Console.WriteLine("To enter data, please fill _input.txt in the program's directory");
Console.WriteLine("At first name all areas (in mind or on paper, etc) starting from 1. ");
Console.WriteLine("First line in _input.txt is empty.");
Console.WriteLine("After enter info to file for all bridges, each from new line:");
Console.WriteLine("Write name of area from one side of bridge <SPACE> other area name \r\n");
Console.WriteLine("For example, area 1 is connected with area 2 ; area 2 is connected with area 3");
Console.WriteLine("1 - 2 - 3");
Console.WriteLine("As you see, there are 2 bridges (1-2 and 2-3). Enter 1+2 lines to _input.txt");
Console.WriteLine("\r\n1\t2");
Console.WriteLine("2\t3");
Console.WriteLine("For 27< number of areas you can enter as Lat. symbols (A for 1; B for 2 etc)");
Console.WriteLine("After providing correct information, run the program again.");

List<int> list = new List<int>(); 
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
int err=0;
int alpha=0; //if not 0 show and get info in alphabet-style

using (FileStream fstream = new FileStream("_input.txt", FileMode.OpenOrCreate)){}

FileStream fRead = new FileStream("_input.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
byte[] readArr = new byte[1024];
int count;
while ((count = fRead.Read(readArr, 0, readArr.Length)) > 0) {
string s= Encoding.UTF8.GetString(readArr, 0, count);
s=s.ToUpper();
char[] dividers = { ' ' , '\r','\n' } ;
string[] seg = s.Split(dividers);
int counter=0;
foreach(string i in seg){
string it=i;
if (counter<3){
if (counter==2) {
char c = i[0];
if(Char.IsDigit(c) == false){alpha=1;}}
counter++;}
int i0=0;
if (alpha!=0){//
try {
int c = i[0];
if (c>=65 && c<=90 ){
	c=c-64;
	it=c+"";
					}
} 
catch(Exception e){}
}// if (alpha!=0)
try {i0 = Convert.ToInt32(it);} catch(Exception e){}
if (i0!=0){list.Add(i0);}
}
}
fRead.Close();

int t=0;
int i1=0;
int i2=0;
foreach(int i in list){
if (t%2==0){i1=i;}else{
i2=i;
if (i1<i2){list1.Add(i1); list2.Add(i2);}else{list1.Add(i2); list2.Add(i1);}
if (i1<1 || i2<1 || i1==i2){err++;}
//Console.WriteLine(i1+" "+i2);
}
t++;
}

if (list.Count%2!=0){err++;}
if (list1.Count != list2.Count || list1.Count<1){err++;}
if (err!=0){Console.WriteLine("\r\n\r\nERROR in _input.txt\r\n\r\n");
Console.WriteLine("Press 'Enter' to quit "); Console.Read();
return;
}else{
Console.WriteLine("...Seems _input.txt is fine...");}

if (alpha==0){Console.WriteLine("Showing in number mode");}
else{Console.WriteLine("Showing in alphabet mode");}

Console.WriteLine("\r\n\r\nGiven bridges with areas on one side  and another:");
for(int i = 0; i<list1.Count; i++){
if (alpha==0){Console.WriteLine((i+1)+" bridge is between:\t"+list1[i]+" "+list2[i]);}
else{
int brcount = i+97;
char brchar = (char) brcount;
int a = list1[i]+64;
char ac = (char) a;
int b = list2[i]+64;
char bc = (char) b;
Console.WriteLine(brchar+" bridge is between:\t"+ac+" "+bc);
}
}

int areac=1;
int[] arr = new int[list1.Count+2]; //areas not more than n+1 bridges and 0 area does not exist
for(int i = 0; i<list1.Count+2; i++){arr[i]=0; }
foreach(int i in list1){arr[i]++;}
foreach(int i in list2){arr[i]++;}
Console.WriteLine("\r\nLet's count number of bridges to all areas:");
int odd=0;
foreach(int i in arr){if (i!=0){
if (i%2!=0){odd++;}
if (alpha==0){Console.WriteLine("Number of bridges in area "+areac+" is: "+i);}
else{
int a2 = areac+64;
char ac2 = (char) a2;
Console.WriteLine("Number of bridges in area "+ac2+" is: "+i);
}
areac++;
}}

if (odd==0 || odd==2){
if (odd==0){Console.WriteLine("Euler cycle exists, all vertices are even. Euler path exists.");} else{
Console.WriteLine("Euler cycle does not exist, 2 vertices are odd. Euler path exists.");}
Console.WriteLine("It's possible to cross all bridges, meeting each bridge only once,");
Console.WriteLine("visiting areas in order (in num mode SPACE separated):");
}
else{
Console.WriteLine("Euler cycle and path does not exist.");
Console.WriteLine("It's NOT possible to cross all bridges, meeting each bridge only once");
Console.WriteLine("The quantity of areas with odd number of bridges is not 0 or 2");
Console.WriteLine("\r\nby OlegTim.Press 'Enter' to quit "); Console.Read();
return;
}

List<List<int>> vert = new List<List<int>>(); //ver[vert num] arraylist{bridge index1,...}
for(int i = 0; i<list1.Count+2; i++){vert.Add(new List<int>{});}

for (int j=0; j<areac ; j++){
for (int p=1; p<list1.Count+1 ; p++){
if (list1[p-1]==j || list2[p-1]==j){if (!vert[j].Contains(p)){vert[j].Add(p-1);}}
}
}

for(int i = 0; i<list1.Count+2; i++){
if (vert[i].Count<1){vert[i]=null;}
}
vert.RemoveAll(item => item == null); //vert is ready
for(int i = 0; i<vert.Count; i++){ 
if (vert[i].Count%2!=0){odd=i;} //if odd vertice exist, start from it
}

List<int> answ = new List<int>(); 
Stack<int> v = new Stack<int>();
int vertnum=odd;
v.Push(vertnum);

while (v.Count>0){//
vertnum = v.Peek();

if (vert[vertnum].Count<1){
answ.Add(vertnum);
v.Pop();
}
else{
int bridge_index = vert[vertnum][0];
int left  = list1[bridge_index]-1;
int right = list2[bridge_index]-1;
vert[vertnum].RemoveAt(0);
for(int y2 = 0; y2<vert.Count; y2++)
{
  for(int y = 0; y<vert[y2].Count; y++)	{
     if (vert[y2][y]==bridge_index){vert[y2].RemoveAt(y);}
										}
}
if (left==vertnum){v.Push(right);}else{v.Push(left);}
}
}//

string ans = "";
for (int i =0; i<answ.Count; i++){
if (alpha==0)	{
ans+=(answ[i]+1)+" ";	
				}
				else{
char mm; mm = (char) (answ[i]+65);	ans+=mm;		
				}
}
Console.WriteLine(ans);

Console.WriteLine("\r\nby OlegTim. Press 'Enter' to quit "); Console.Read();
}
}
