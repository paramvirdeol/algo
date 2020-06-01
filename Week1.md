## Quick-Find

**Cost Model**: Number of array accesses (for read or write)

			| initialize	| union		| find
			-----------------------------------
quick-find	| N				| N			| 1
quick-union	| N				| N			| N (worst case)
weighted QU	| N				| lg N		| lg N

**Issue:** Union too expensive
- Takes N*N array accesses to produce sequence of N union commands on N objects. Takes quadratic time.


## Quick-Union
- Lazy approach (tree)

* Data Structure: int array id[] of size N
* Interpretation: id[i] is parent of i
* Root of i is id[id[....id[i]...]]

Quick-union issues:
* Trees can get tall
* Find too expensive

## Improvement 1: Weighted quick-union
* Modify quick-union to avoid tall trees
* Keep track of size of each tree
* Balance by linking root of smaller tree to root of larger tree

Data Structure: Same as quick union, but maintain extra array sz[i] to count number of objects in the tree rooted at i.
Find: return root(p) == root(q)
Union: Link root of smaller tree to root of larger tree. Update the sq[] array.

Running time:
* Find: takes time proportional to depth of p and q
* Union: takes constant time, given roots

- Depth of any node x is at most lg N

## Improvement 2: Quick-union with path compression
- Just after computing the root of p, set the id of each examined node to point to that root.
- Keeps the tree almost completly flat.

## Weighted quick-union with path compression [Hopcroft-Ulman, Tarjan]
- In theory, this algorithm is not linear
- In practice, this algorithm is linear

**Fact:** It was proved by Fredman and Sachs that there is no linear time algorithm for the union-find problem 

## Summary

Algorithm				| worst-case time
----------------------------------------------------
quick-find				| M N
quick-union				| M N
weighted QU				| N + M log N
QU + PC					| N + M log N
weighted QU + PC		| N + M log N

- M union-find operations on a set of N objects

Ex. Power(10,9) unions with Power(10,9) objects 
* WQUPC reduces time from 30 years to 6 seconds


Trial Problems:
* Social network connectivity. Given a social network containing n members and a log file containing mm timestamps at which times pairs 
of members formed friendships, design an algorithm to determine the earliest time at which all members are connected 
(i.e., every member is a friend of a friend of a friend ... of a friend). Assume that the log file is sorted by timestamp and that 
friendship is an equivalence relation. The running time of your algorithm should be m log n or better and use extra space proportional to n.
	HINT: union-find

* Union-find with specific canonical element. 
Add a method method find() to the union-find data type so that find(i) returns the largest element in the connected component containing i. 
The operations, union(), connected(), and find() should all take logarithmic time or better.
	HINT: maintain an extra array to the weighted quick-union data structure that stores for each root i the large element in the connected component containing i.

* Successor with delete. 
Given a set of n integers S = { 0, 1, ... , n-1 } and a sequence of requests of the following form:

	- Remove x from S
	- Find the successor of x: the smallest y in S such that y >= x.
design a data type so that all operations (except construction) take logarithmic time or better in the worst case.
	Hint: use the modification of the union−find data discussed in the previous question.
