#include <iostream>

using namespace std;


int contorSolutii = 0;
int n = 8;
int regine[100];

bool verificare(int aux)
{
    for (int i = 0; i < aux; ++i)
        if(regine[i] == regine[aux] || aux-i == abs(regine[aux]-regine[i]))
        return false;
    return true;

}

bool solutie(int aux)
{
    if(aux == n)
        return true;
    return false;
}

void afisareSolutii()
{
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            if(regine[j] == i)
                cout << "Q";
            else
                cout << "-";
            cout << " ";
        }
        cout << endl;
    }
    cout << endl;
    contorSolutii++;
}

void backTracking(int coloana)
{
    for (int i = 0; i < coloana; ++i) {
        regine[coloana] = i;
        if(verificare(coloana))
        {
            if (solutie(coloana)) {
                afisareSolutii();
            } else
                backTracking(coloana + 1);
        }
    }
}

int main()
{
    backTracking(1);


    return 0;
}
