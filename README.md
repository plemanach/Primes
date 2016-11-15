# Primes

PrimesTools allow to print the multiplication table of the Nth prime numbers.

For example :

PrimesTools.exe 3

   |   |   |   |
---|---|---|---|
    |   2|   3|   5
   2|   4|   6|  10
   3|   6|   9|  15
   5|  10|  15|  25



The Algo generating the Nth prime numbers use a small amount of memory and is pretty performant.

The matrix generation itself is not that perforamt as it is storing the all matrix in memory and will deserve some kind
of lazy algo to calulate the matrix on the go.


The generation of prime numbers could be improved to use a factorization wheel, or explore more complexe algo:

https://en.wikipedia.org/wiki/Wheel_factorization

https://en.wikipedia.org/wiki/Sieve_of_Atkin

