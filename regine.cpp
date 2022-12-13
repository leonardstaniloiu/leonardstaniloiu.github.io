#include <iostream>

using namespace std;
int st[11],k,i,as,ev,j;
int n = 8;
void init()
{
    st[k]=0;
}
int succesor()
{
    if(st[k]<n)
    {
        st[k]++;
        return 1;
    }
    return 0;
}
int valid()
{
    for(i=1;i<k;i++)
        if(st[i]==st[k]||abs(st[i]-st[k])==abs(i-k))
            return 0;
    return 1;
}
int solutie()
{
    return (k==n);
}
void tipar()
{
    for(i=1;i<=n;i++)
    {
        for(j=1;j<=n;j++)
            if(st[i]==j)
                cout<<"\tQ";
            else
                cout<<"\t- ";
        cout<<endl;
    }
    cout<<endl;
}
int main()
{

    int contor = 0;
    k = 1;
    init();
    while(k)
    {
        do
        {
            as=succesor();
            if(as)
                ev=valid();
        }
        while(!(as&&ev||!as));
        if(as)
            if(solutie())
            {
                contor++;
                cout << "Solutia cu numarul:" << contor << endl;
                tipar();
                cout<<endl;
            }
            else
            {
                k++;
                init();
            }
        else
            k--;
    }
    return 0;
}
