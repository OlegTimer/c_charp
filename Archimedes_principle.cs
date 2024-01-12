class Archimedes_principle
{
static void Main (string[] args ){
Console.WriteLine("_ Archimedes' principle (Archimedes's law) calculation _\r\n");
Console.WriteLine("Do you want to see list of density?\r\nEnter <y> and <Enter> for yes");
Console.WriteLine("Or press <Enter> to skip");
string s = Console.ReadLine();
if (s=="Y" || s=="y"){
Console.WriteLine("\r\nDensity (tonn_in_cubic_meter OR gram_in_cubic_cm):");
s="gold		19.3\r\nquicksilver	13.6\r\ncopper		8.9\r\niron		7.8\r\naluminium	2.7\r\nmarble		"+
"2.7\r\nglass		2.5\r\nbrick		1.5\r\nhoney		1.35\r\nwater		1\r\nice		0.9\r\noil"+
"		0.9\r\nkerosene	0.8\r\nalcohol		0.8\r\noak		0.7\r\npine		0.4\r\nchlorine	0.00321\r\nair"+
"		0.00129\r\nhelium		0.00018\r\nhydrogen	0.00009";
Console.WriteLine(s);
}

double g = 9.8;
int err=0;
Console.WriteLine("\r\nEnter volume of a body in cubic meters, please (i.e. 1.3):");
s = Console.ReadLine();
s = s.Replace ( "." , "," );
double v=-1;
try{v = Convert.ToDouble(s);}catch{}
if (v<0){err++;}
Console.WriteLine("Enter density of a body tonn_in_cubic_meter OR gram_in_cubic_cm (i.e. 0.7):");
s = Console.ReadLine();
s = s.Replace ( "." , "," );
double b=-1;
try{b = Convert.ToDouble(s);}catch{}
if (b<0){err++;}
Console.WriteLine("Enter density of an area tonn_in_cubic_meter OR gram_in_cubic_cm (i.e. 1):");
s = Console.ReadLine();
s = s.Replace ( "." , "," );
double a=-1;
try{a = Convert.ToDouble(s);}catch{}
if (a<0){err++;}
if (err!=0){Console.WriteLine("\r\nERROR_input"); Console.Read(); return;}

double fa = g*v*a*1000;
double fg = g*v*b*1000;
Console.WriteLine("\r\nFor object with volume "+v+" m^3 and density "+b+" t/m^3");
Console.WriteLine("inserted into area with density "+a+" t/m^3");
Console.WriteLine("Archimedes force is: "+fa+" H");
Console.WriteLine("Gravity force is: "+fg+" H");
Console.Write("Body will ");
if (fa-fg<-0.01){Console.Write(" NOT ");}
Console.Write(" float.");
Console.WriteLine("\r\nby OlegTim. Press 'Enter' to quit "); Console.Read();
}
}