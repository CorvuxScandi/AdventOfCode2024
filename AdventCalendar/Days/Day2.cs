using System;

namespace AdventCalendar.Days;

public class Day2 : IDay
{
    public Task<CalendarAnswer> Run()
    {
        List<string> lines = [.. input.Split("\r\n")];
        int numofValid = lines.Select(line =>
        {
            bool isValid = true;
            string[] parts = line.Split(" ");
            int[] numbers = parts.Select(int.Parse).ToArray();
            bool isIncreasing = numbers[0] < numbers[1];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int diff = Math.Abs(numbers[i] - numbers[i + 1]);
                if(diff < 1 || diff > 3 || (numbers[i] < numbers[i + 1]) != isIncreasing)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }).Count(x => x);

        return Task.FromResult(new CalendarAnswer(true, numofValid.ToString()));
    }

    public Task<CalendarAnswer> RunAdvanced()
    {
        List<string> lines = [.. input.Split("\r\n")];
        int numofValid = lines.Select(line =>
        {
            bool isValid = true;
            string[] parts = line.Split(" ");
            List<int> numbers = parts.Select(int.Parse).ToList();


            bool firstOffence = false;
            bool isIncreasing = numbers[0] < numbers[1];

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int pos1 = numbers[i];
                int pos2 = numbers[i + 1];
                int diff = pos1 - pos2;

                
                
                if(Math.Abs(diff) < 1 )
                {
                    if(firstOffence)
                    {
                        isValid = false;
                        break;
                    }
                    firstOffence = true;
                    numbers.RemoveAt(i);
                    i = -1;
                }
            
                if(diff < 1 || diff > 3 || (pos1 < pos2) != isIncreasing)
                {
                    if(firstOffence)
                    {
                        isValid = false;
                        break;
                    }
                    firstOffence = true;
                    numbers.RemoveAt(i);
                    i = -1;
                }
            }
            return isValid;
        }).Count(x => x);

        return Task.FromResult(new CalendarAnswer(true, numofValid.ToString()));
    }

    private string input2 = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
    private string input = @"48 51 52 53 52
86 87 88 91 91
22 25 28 31 32 36
65 66 68 69 71 72 75 82
39 42 41 44 47
20 21 22 19 20 22 23 22
25 26 27 29 31 34 33 33
54 57 59 61 58 59 60 64
17 19 20 22 25 26 24 31
86 88 90 91 92 92 93 95
23 25 25 28 26
56 57 59 60 61 61 62 62
73 75 76 76 79 83
10 13 16 16 18 21 23 30
43 45 49 52 55 58 59 61
69 72 76 77 75
6 9 11 14 18 18
72 74 77 81 84 86 87 91
18 19 22 26 29 32 39
2 5 8 13 16 17
67 70 72 79 78
17 18 23 26 26
68 70 73 79 82 86
71 72 73 79 81 86
14 13 14 17 20 22 25 27
70 67 70 71 74 71
84 83 84 87 88 88
29 27 30 31 32 36
80 78 79 80 82 87
45 42 44 46 49 46 47 49
41 38 39 41 38 41 42 41
69 66 64 65 65
87 86 89 91 89 92 96
30 29 30 32 29 32 37
83 80 80 83 86 87 89 90
56 55 55 57 56
50 47 49 51 51 54 54
8 7 7 10 11 15
15 14 14 15 16 18 21 26
24 21 25 28 31 33 35
36 34 36 37 41 38
43 40 44 46 46
87 84 86 90 94
34 31 34 36 40 41 48
57 55 57 60 66 68 71 73
42 41 46 48 50 49
48 46 53 56 56
86 83 85 87 92 96
67 64 70 72 78
56 56 57 58 61 63
54 54 55 57 59 57
73 73 75 77 79 81 81
30 30 31 33 36 40
64 64 65 66 68 70 73 80
55 55 53 55 58 60 63
80 80 77 80 83 86 85
55 55 56 59 58 59 61 61
31 31 32 30 34
38 38 37 40 46
75 75 76 79 81 81 83 86
70 70 71 71 72 69
13 13 15 18 18 21 21
22 22 25 28 28 32
72 72 75 76 76 83
65 65 69 72 75 76 77 80
43 43 46 48 52 51
21 21 22 24 28 30 30
55 55 59 61 63 66 69 73
13 13 16 17 21 27
61 61 64 66 68 74 76
73 73 74 79 80 79
22 22 25 27 30 37 37
69 69 70 75 79
80 80 86 89 95
29 33 35 36 39 42 45
62 66 69 71 72 75 78 77
31 35 36 37 38 38
53 57 60 62 65 68 69 73
45 49 50 51 53 54 55 61
37 41 43 41 42 44 47 49
87 91 93 90 91 93 92
21 25 26 23 26 28 28
10 14 13 15 18 21 25
13 17 20 22 23 20 23 30
72 76 76 77 78
19 23 26 26 24
80 84 84 85 85
39 43 46 46 50
9 13 15 16 16 18 24
81 85 88 90 93 97 98
37 41 43 47 45
24 28 32 35 36 39 39
40 44 45 49 51 52 56
42 46 50 53 56 63
4 8 14 16 17 20 22 23
30 34 40 42 40
42 46 47 48 50 57 57
69 73 78 81 85
41 45 47 53 59
57 63 64 65 68
78 83 86 88 90 92 90
38 43 46 49 50 50
15 20 21 23 26 29 33
22 27 29 30 36
69 74 76 79 82 84 83 86
7 14 11 14 13
19 26 25 28 28
67 74 75 77 76 80
60 67 68 66 69 71 76
76 83 85 86 88 88 89
78 84 84 85 87 90 91 89
15 21 21 23 25 27 28 28
63 69 69 71 73 74 78
57 64 64 65 72
39 46 47 50 51 55 56 59
80 86 89 91 95 97 94
4 11 15 16 16
5 11 13 17 21
56 61 64 66 67 71 73 78
9 14 17 20 27 30 32
80 86 87 92 91
64 70 72 75 82 82
23 30 33 35 42 46
54 61 64 67 72 79
90 88 85 84 87
96 94 92 90 87 84 84
57 56 54 52 50 49 48 44
51 49 46 43 42 37
25 22 19 21 20 17 14 13
55 53 52 49 51 50 53
6 4 7 4 4
20 19 16 17 16 14 10
79 76 73 70 73 71 65
94 91 91 88 87 84
67 65 63 62 59 59 62
18 16 14 14 11 11
55 53 51 50 47 46 46 42
39 37 34 33 33 27
54 51 47 46 43
31 30 26 25 26
43 40 39 35 34 34
98 97 94 90 89 86 82
79 78 76 72 70 68 61
42 41 40 37 34 27 24
30 28 25 22 15 17
80 78 76 69 68 67 67
57 54 49 48 46 42
82 81 80 74 73 70 68 61
12 13 11 9 7
44 46 45 43 45
75 78 77 75 75
66 67 64 63 59
84 85 82 81 78 76 75 70
57 58 60 58 55 54 53 52
52 53 54 52 55
82 85 83 80 81 79 77 77
25 27 26 23 24 23 20 16
53 56 53 50 51 46
87 90 90 87 84 82
14 17 14 13 13 15
84 87 86 86 86
24 26 25 25 23 20 17 13
26 29 28 27 26 23 23 16
74 75 71 68 66 64
96 97 94 91 87 85 87
56 59 58 54 54
65 67 66 62 58
67 70 66 65 63 62 57
84 86 83 76 73 71
58 59 56 53 50 45 48
86 87 82 79 79
28 31 29 24 20
84 86 81 80 74
90 90 89 86 83 80 79
8 8 7 5 4 3 5
29 29 28 26 24 23 20 20
41 41 38 35 34 31 30 26
54 54 53 50 45
82 82 79 78 77 79 76
96 96 93 90 88 89 90
65 65 64 62 65 64 64
11 11 13 10 9 8 6 2
34 34 37 35 30
8 8 8 7 6 5
38 38 38 36 37
16 16 16 14 13 10 10
16 16 14 14 12 8
70 70 67 65 65 59
51 51 50 46 43 41
45 45 43 39 41
75 75 73 70 68 67 63 63
83 83 81 77 75 71
68 68 64 62 59 52
99 99 97 92 91 90
47 47 41 38 41
66 66 64 62 61 56 56
94 94 87 84 80
73 73 71 64 62 60 53
18 14 13 12 10 9
84 80 78 76 74 71 69 71
87 83 82 80 77 74 74
54 50 47 45 42 40 38 34
24 20 18 15 9
60 56 53 55 52
51 47 46 47 50
46 42 39 37 38 38
54 50 48 47 50 46
77 73 76 74 73 71 69 63
53 49 47 46 45 45 44
19 15 13 13 11 8 6 7
46 42 40 40 39 36 36
96 92 92 91 87
27 23 23 22 19 14
93 89 87 84 83 79 76 75
62 58 57 54 50 53
98 94 91 87 86 86
74 70 67 63 60 56
82 78 75 71 69 68 65 59
51 47 45 44 37 36
72 68 66 60 59 60
62 58 57 52 50 50
35 31 24 21 17
72 68 65 62 57 52
94 87 86 84 83 82
99 94 91 90 88 86 87
40 35 32 31 30 30
95 90 88 87 83
90 84 81 78 76 74 71 66
62 57 56 58 57 56 53
29 23 24 22 25
87 81 78 79 79
16 9 8 9 8 4
23 16 19 16 14 13 7
80 73 70 67 67 65
88 81 79 77 75 75 78
25 19 19 18 16 16
76 69 68 67 66 66 64 60
26 19 18 17 17 10
26 21 19 15 13
47 40 36 35 37
92 87 83 81 79 77 76 76
42 35 34 30 28 27 23
31 24 21 17 16 13 11 6
73 67 66 63 61 59 53 52
58 52 50 45 44 46
31 24 17 14 11 11
32 26 21 20 17 14 10
45 40 34 33 31 28 21
61 62 64 67 70 72 70
29 30 32 34 34
89 90 92 93 97
26 28 31 32 35 42
88 90 87 88 91 93 96 99
68 71 74 76 77 74 71
83 85 84 85 85
57 58 59 57 61
27 30 32 35 33 34 37 44
59 60 63 63 66 67
76 78 79 82 84 84 85 82
44 47 50 50 53 54 55 55
23 25 25 28 32
11 14 17 17 20 27
49 51 54 55 56 60 63
52 55 57 61 60
35 36 38 42 44 44
9 11 15 18 19 21 25
78 81 82 86 89 95
54 56 61 63 66 69
86 89 96 99 96
31 34 35 37 38 44 45 45
70 71 76 78 81 82 83 87
29 31 33 38 39 40 41 48
68 66 68 69 70
84 81 82 84 87 89 87
72 70 72 75 75
18 15 17 18 22
8 7 10 12 13 16 19 24
7 6 9 6 7
61 58 60 63 61 63 62
52 49 52 55 56 54 56 56
77 76 77 79 76 78 82
72 69 66 67 74
35 34 35 37 37 38
59 58 58 59 56
51 49 49 52 52
49 48 48 51 54 56 60
41 40 42 43 43 46 49 56
81 79 83 85 86 89 90
93 92 96 97 99 97
35 32 33 34 38 38
4 2 3 7 8 11 14 18
45 42 46 47 50 57
56 53 54 57 64 65
67 66 68 69 72 79 82 80
45 44 47 50 52 59 61 61
14 13 20 23 27
51 49 50 53 54 60 62 69
80 80 82 84 87
71 71 73 75 76 79 81 78
39 39 42 45 45
68 68 70 73 74 78
68 68 70 72 79
89 89 88 91 92 93
89 89 90 87 89 91 94 92
21 21 22 24 22 23 24 24
46 46 47 44 45 48 50 54
17 17 15 16 17 23
79 79 79 82 83 85
44 44 46 46 47 48 45
96 96 96 98 98
3 3 3 6 8 12
5 5 8 8 11 14 21
78 78 81 85 88 90
3 3 7 10 12 15 13
15 15 19 20 22 23 26 26
9 9 10 14 17 21
13 13 17 18 19 25
14 14 19 20 21
86 86 91 94 95 93
57 57 58 63 63
1 1 4 7 12 15 16 20
60 60 63 66 71 76
9 13 16 19 21 24
52 56 58 61 63 64 62
77 81 84 86 89 89
9 13 14 17 20 21 25
60 64 65 67 68 69 70 76
30 34 33 36 39 42 45 46
88 92 93 96 95 94
1 5 4 5 6 6
57 61 63 66 69 71 68 72
51 55 53 54 61
20 24 25 25 28 31 34 37
66 70 70 72 70
91 95 96 96 96
53 57 59 62 64 64 68
4 8 10 10 12 19
43 47 51 53 55 58
49 53 55 56 60 61 64 62
28 32 36 39 39
79 83 84 88 90 94
48 52 54 56 60 66
71 75 76 81 82
39 43 50 52 50
39 43 44 50 53 56 59 59
40 44 46 47 50 56 60
42 46 49 55 60
21 27 29 31 32 33 34
27 32 33 36 37 34
68 75 76 78 78
3 10 11 14 17 18 19 23
5 10 11 13 16 22
17 24 26 28 30 32 30 31
30 36 37 35 34
34 40 38 40 40
84 90 91 93 94 92 96
1 6 3 4 7 8 10 16
58 63 66 68 70 73 73 74
61 68 68 70 71 70
3 10 12 12 13 13
8 14 16 16 17 20 21 25
76 82 85 85 86 92
3 8 10 13 14 15 19 21
47 52 53 56 60 58
85 91 92 93 94 98 99 99
74 80 81 82 83 87 90 94
77 83 87 89 90 95
54 59 61 63 66 73 74 77
41 48 49 56 54
68 74 77 80 87 87
13 18 24 26 30
15 20 23 26 33 36 43
40 38 35 32 30 28 30
56 53 52 50 47 45 42 42
93 92 91 90 89 85
22 19 16 14 12 9 4
40 37 34 33 31 32 30 28
37 34 35 33 31 32
61 58 61 60 57 57
19 17 14 11 13 11 8 4
85 84 81 80 83 81 79 74
17 15 15 13 12 11 10 9
76 74 73 73 71 68 69
22 20 18 17 17 14 11 11
75 73 71 71 67
94 91 90 90 87 86 84 77
29 26 22 20 19
62 61 59 58 56 52 55
75 73 70 68 64 64
23 20 17 13 12 8
79 76 75 72 70 66 59
39 36 34 31 24 21
36 35 34 28 25 22 25
80 78 77 76 73 68 68
22 19 17 15 10 8 4
80 78 76 71 68 67 61
81 83 82 79 77 75 74 71
27 30 28 25 22 19 18 19
16 18 16 15 14 12 12
51 53 50 48 44
51 54 52 49 43
15 16 14 17 15 13 11 8
68 69 72 71 68 67 70
19 22 23 21 20 20
16 18 16 19 16 12
38 40 38 35 36 33 30 23
76 78 75 74 74 71 68
19 21 21 19 16 14 17
59 60 60 59 58 58
33 35 33 31 31 28 26 22
32 35 35 33 27
57 58 54 52 49 46 43 40
34 35 34 30 29 26 28
52 55 52 48 48
49 50 48 45 44 40 38 34
40 42 39 37 35 31 30 23
74 75 73 70 67 64 58 55
15 18 16 11 9 10
36 37 36 34 32 31 25 25
81 82 80 73 69
89 91 88 86 79 76 69
20 20 17 16 15
85 85 84 82 81 78 79
63 63 62 60 59 59
87 87 84 81 77
36 36 35 33 32 31 25
62 62 64 61 60 57 55
58 58 55 58 61
36 36 35 32 35 35
36 36 34 32 33 29
93 93 92 93 87
33 33 30 30 27
88 88 87 86 86 87
95 95 92 92 92
35 35 35 32 28
59 59 56 56 49
69 69 67 63 62 61
14 14 10 9 7 6 3 5
72 72 70 69 65 64 64
73 73 72 69 65 62 61 57
47 47 46 42 36
65 65 64 61 58 52 50
37 37 30 28 26 28
89 89 87 82 82
19 19 17 14 7 6 2
24 24 22 21 15 8
44 40 39 38 35
72 68 65 64 67
46 42 39 38 36 33 32 32
88 84 81 80 78 77 73
90 86 83 80 79 76 70
49 45 42 39 41 40
95 91 90 91 92
34 30 31 30 27 27
46 42 41 44 41 40 36
84 80 77 78 73
29 25 25 22 21 20 19 16
79 75 75 73 71 74
64 60 58 55 55 54 51 51
83 79 77 74 74 72 71 67
86 82 79 79 77 75 69
44 40 36 33 30 28 27
52 48 47 43 40 43
38 34 30 27 25 25
40 36 33 29 26 22
67 63 61 59 55 49
94 90 87 82 79 78 75
48 44 42 37 35 34 37
61 57 54 47 45 45
94 90 87 82 78
60 56 53 50 43 38
88 81 78 75 74 71
98 91 90 89 88 91
92 85 83 81 79 77 74 74
30 23 20 19 17 13
37 32 30 27 25 24 19
66 59 57 56 57 55 54
90 84 83 86 85 83 84
16 10 9 12 11 10 10
68 63 60 57 58 55 51
91 86 83 84 79
36 29 29 27 26
49 44 44 42 44
87 82 79 76 76 73 73
48 41 38 38 36 33 32 28
23 17 14 13 10 10 4
80 74 70 68 65
64 58 57 53 52 51 52
25 20 17 14 13 9 8 8
47 40 37 33 32 28
76 69 65 64 63 60 57 52
40 35 34 27 26 23 22
24 19 18 15 12 6 8
73 66 64 61 58 51 51
98 91 86 84 82 81 77
68 62 61 54 51 48 41
24 28 32 33 35 38 40 40
10 10 12 10 13 16
95 92 90 86 84 82 80 81
33 37 40 44 42
83 80 78 77 73 70
65 71 72 75 76 79 80 85
11 6 4 3 2 1
62 66 69 70 73 75
57 60 62 69 70 73 74 80
58 61 58 54 54
92 93 92 89 87 86 86
28 32 36 37 40 44
38 40 40 42 40
83 77 76 73 68 66 63 60
40 41 44 46 48 48
91 87 84 87 85 85
1 1 8 10 8
9 9 10 14 16 21
91 92 93 96 97 94 95 95
45 42 45 47 50 54
45 50 51 52 53 55 58 56
26 23 27 28 31 33 35 35
86 89 88 87 86 84 77
22 22 24 25 26 29 30 36
33 34 38 39 40 41 42 41
45 44 45 47 47 49 50 50
42 39 38 34 33 31 25
11 10 9 7 2 1 1
18 17 16 10 9 7
51 46 42 39 38 37 34
42 43 43 41 34
44 42 46 49 47
28 24 21 19 20 17 11
11 15 17 20 20 25
78 72 69 63 62 61 60 60
40 44 47 49 50 50 53
17 22 25 28 32 29
38 34 33 33 34
80 78 76 76 76
69 65 64 59 56 55 55
3 8 10 12 15 19 21 21
4 1 1 3 5 7 8 11
97 97 96 93 91 88 85 82
26 27 34 35 33
57 57 58 61 63 70 72 76
20 22 20 21 20 17 16 16
59 63 61 62 64 67 68 72
37 39 37 39 42 44 46 47
39 33 32 29 28 24 24
52 46 43 42 39 36 38 38
76 73 72 71 73
44 41 44 47 51 52 57
46 43 40 37 31
52 52 52 54 60
24 31 32 32 34 35
20 20 23 26 27 27 29 31
41 43 44 46 49 53
13 19 19 22 25 31
62 58 57 55 53 56 57
53 51 54 54 58
79 75 71 69 69
33 33 31 29 28 25 22 22
84 80 73 70 68 67 65 61
42 40 41 43 49 50 52 53
23 23 25 27 29 31 33
21 22 18 16 14 8
97 93 92 93 91 90
78 82 88 90 90
58 52 49 51 48 47 40
75 75 78 76 71
29 28 26 24 18 16 14 7
51 55 52 54 59
23 26 21 19 22
36 36 36 37 39 37
76 70 69 69 66 65 63
65 69 71 72 73 72 72
41 41 40 34 32 30 24
48 44 41 39 37
85 83 86 89 90 90
73 79 82 83 86 88 91 95
2 7 8 12 14 17 19 21
5 5 6 8 9 12 12
63 63 64 71 74 77 77
18 16 18 19 25 27 29 34
77 77 74 73 70 68 70
7 11 16 19 16
27 26 33 36 37 37
44 42 41 39 41 38
94 95 94 93 86 85 83
77 77 78 75 78 78
83 79 78 78 75
30 32 31 25 22 21 20 14
13 16 15 13 10 6
17 21 23 26 32 33
48 52 49 50 53
92 89 87 84 82 81 81
68 64 62 56 54 51 54
41 43 40 37 35
34 30 29 27 30 26
31 28 29 28 30 35
22 24 25 26 28 29 32 31
62 65 61 58 55 53 49
67 74 78 80 82 85 88 93
23 21 22 24 24 23
93 90 88 85 85 83 78
56 62 61 64 65 70
54 61 62 63 65 68 66 66
84 81 80 76 75 72 69 65
71 71 70 67 68 68
33 33 35 38 41 45 48 49
32 29 35 36 37 40 37
52 58 61 62 62 60
21 18 18 21 26
81 81 83 87 87
79 79 78 79 82 83 86 84
94 94 91 88 87 85 82 75
92 88 87 85 83 81 78 78
30 30 28 27 26 26 23 26
40 36 32 30 29
59 59 62 65 65 66 66
39 46 49 50 50 50
13 13 13 11 8
1 3 6 7 10 7 10 14
76 77 74 71 71 68 70
30 27 29 26 28
95 95 94 90 86
35 36 34 32 29 24 22 18
24 27 28 31 34 36 35 34
46 46 48 47 54
81 74 74 73 72 68
54 52 53 57 59 60 63 66
41 39 42 41 37
31 29 32 30 32 32
77 73 70 63 58
19 16 18 23 26 30
15 18 19 17 20 26
26 30 32 36 37
44 43 46 48 47 51
78 80 83 84 85 92
4 9 11 12 13 15 17
60 61 63 67 70 72 72
41 37 36 36 32
43 41 39 37 35 30 32
21 25 26 31 35
21 22 23 24 31 31
81 86 93 96 95
89 89 92 95 99 98
63 62 65 63 65 67 66
68 62 59 60 59 56 53 49
26 27 25 22 19 13 12 12
86 89 88 84 82 80
19 19 20 27 30 32 37
56 59 61 63 63 65 68 72
64 71 74 73 74 76 79 83
17 11 9 7 6 1 4
25 19 18 16 14 12 8 2
85 81 78 77 73
25 25 23 21 17 20
52 51 49 47 44 42 38
60 56 53 53 52 52
21 23 25 23 20 23
21 21 18 14 12 10 7
24 26 24 21 18 18 15 14
73 68 66 64 62 58
46 49 56 58 60 62 66
47 54 56 58 58
33 33 32 35 31
91 86 84 83 81 84
6 8 9 10 12 18 21 22
57 53 52 49 44
82 78 77 77 70
42 43 42 42 38
67 65 64 62 60
91 93 94 95 97 99
85 86 87 88 91 94
36 34 32 31 28 25
23 22 20 18 16 13 10 7
88 91 94 96 97
92 93 95 96 97
23 24 26 29 32 35
94 91 89 88 86
45 44 41 40 37 36 34 32
98 95 92 89 86 84
74 71 69 68 65 64 63 60
24 26 27 29 30 31
23 20 18 17 16 15 13 11
92 91 89 88 85 83 81 80
86 89 91 94 96
37 36 34 33 32 31
10 12 15 17 19 22 23
55 53 50 47 46 43 42
22 19 16 13 12 10 8 7
36 38 41 44 45 48
39 37 36 34 32
78 80 81 82 85 87 89
57 58 59 60 63
72 69 67 66 64
71 74 76 77 80 81 83 86
39 40 43 44 47 48 51
38 37 34 31 29 26 25 23
4 7 9 10 12
30 28 26 25 24 22 21
24 25 28 30 31 32
49 47 46 44 43 41 40
45 48 49 50 51 52 54
43 45 48 49 50 53 55
64 61 59 57 55 54 52 51
40 41 42 45 47 50 51 52
43 41 39 37 36 34
69 68 65 64 61 60
4 7 9 12 13
35 34 33 32 30 28 25
55 54 53 51 48
59 61 62 65 66 67 70 71
81 80 77 76 75 72
86 85 83 80 78 76 75 73
94 92 91 89 88
95 93 92 90 88 85 82 80
73 75 77 78 79
43 41 38 37 35 34 32
15 16 17 20 21 24
28 27 24 23 20 17 14
60 57 54 53 50 47 44
74 72 70 68 66 63 60
60 61 63 64 67 70 72 73
77 78 79 82 85 87
24 21 20 18 17 16 14
35 34 33 31 28 27
29 28 26 25 23
29 31 32 33 36 37 40 42
59 62 65 67 69
70 68 65 63 61 58
66 69 72 75 77 78 79 81
97 95 93 92 91
46 45 44 42 39 37 36 35
46 44 43 41 38 35
17 14 13 12 9 6 5
6 9 10 12 13
27 24 23 22 19 17 16 15
78 76 75 72 69 66 65
11 10 8 7 5
66 68 69 70 71 73 74
82 80 79 78 75 72 71 68
99 96 94 91 89
57 55 53 51 48 46 43 42
10 11 13 16 19
37 40 41 43 46 48 51
5 6 7 8 9 12
83 84 87 88 91 94 96 98
76 75 74 72 71 69 68
11 14 16 17 20
48 47 45 42 41 39 37 34
11 14 15 17 18 19
64 61 59 56 53 51 50
68 66 63 62 61
24 26 27 30 31 34 37 38
71 73 75 78 80 82 85
37 39 40 41 42 44 45 48
22 23 25 26 28 31 32
37 34 32 31 28
26 27 30 32 33
43 44 47 49 52 54 55
49 46 45 44 43 42
94 92 91 89 86 83 82
31 32 34 35 36 37 40 43
95 94 91 90 88 86 85
31 33 36 37 40 43 44 45
75 72 71 70 69
78 75 72 71 69 66 65 64
53 51 48 46 44 43
64 63 62 60 59
39 42 45 48 49 52 55 56
91 88 86 84 82 80
12 15 18 20 21 22 25 26
41 39 38 37 35 33 31 30
44 41 40 39 36
14 16 19 22 25
56 57 59 62 64
99 97 95 94 92 91 89 87
83 81 79 77 76 73
52 54 56 58 59 61 63
47 49 51 52 54 55 58
18 21 22 23 26 27 28 29
39 41 43 45 46 48 50
44 43 42 41 38 36
76 73 70 68 66 63 62
37 34 32 31 28 25
40 38 37 34 32 29
58 55 53 50 48 46
39 36 33 32 30 27
43 44 45 47 48
23 26 27 29 32 33 34
90 87 85 83 81 80 78
19 20 21 23 24 27
76 75 73 72 71
83 82 79 77 75 73 72
19 17 15 13 11
72 70 69 68 65 63 60
56 54 51 48 46 44
52 51 48 46 43 40
33 32 31 28 27 24 21
11 10 8 6 5
92 89 87 86 84 81 79
86 87 89 91 93 95
59 61 64 67 68 69 72 75
28 31 32 35 36 39 41
86 89 90 93 94 96
76 79 82 83 86 87 88
29 27 26 23 21 20
51 53 54 56 58 61 62 65
77 78 81 83 84 87 88
38 40 41 42 44 47
47 45 44 43 41
56 59 62 64 67 70 71
9 11 14 16 19 20
29 28 27 24 21 20
30 27 25 23 20 19 16 13
84 83 82 79 77
46 49 50 53 54 55 56
21 24 25 27 29 32 33
14 15 16 18 20
85 82 79 78 77 76 75 73
63 60 59 57 55
32 34 37 40 41 44 45 48
53 56 58 59 61
12 11 9 8 5 4 3
84 81 78 77 76 75 73 72
44 43 42 39 37
76 73 70 68 67
86 89 91 93 94 97 99
77 80 81 82 85
19 16 13 11 9 8 5
19 22 24 27 30
18 20 23 24 26
64 66 68 69 72 74 77 78
78 75 73 72 70 67 65 64
37 38 41 43 46 48
36 35 34 31 28 26 24 21
27 30 31 34 35 37 39 41
80 83 84 86 89
61 64 66 69 70
50 53 54 57 60 61 62 63
57 60 63 66 69 70 73
60 57 54 52 49 48 45 43
48 46 43 41 39 37 35 33
21 22 23 24 26
64 65 68 69 71 74
46 49 50 51 52 54 56
20 18 16 15 14 13 11 9
34 32 29 27 24 21 18 15
16 14 12 11 10
18 19 22 24 25
53 51 48 46 44 42 39
77 74 72 69 68 66 65
25 22 21 20 17 14 13
33 30 28 27 25 22 19 17
29 28 26 23 21
40 39 38 36 33 32
63 60 57 54 52 49 47 45
84 85 86 89 91 93 96 99
20 23 24 25 28
6 8 9 12 14 16
52 53 56 59 62 65 66
51 54 57 58 61 63 65
36 34 33 31 29 28 27
61 62 65 66 69 70 71 74
25 26 29 31 34 37 40 42
48 47 46 44 41 40
31 34 37 39 42 43 46 48
95 93 91 88 85 83 80 77
75 72 70 68 67 66
15 18 21 22 23 26 29 30
94 93 90 89 88 87 84 82
36 34 33 31 29 26
65 64 63 60 59
12 14 17 19 22 25 28 30
20 18 15 13 11 8 7 4
11 13 15 16 19
71 69 66 65 64 61
61 62 65 67 70 73 74 76
51 49 46 45 43
61 59 58 56 53 50 48
29 31 33 36 39 42 45 47
74 76 79 82 84 86
93 90 87 84 83 82 81
70 72 74 77 79 80 81 83
89 90 93 95 98
41 42 44 46 48 50 53 54
31 29 26 24 23 20 19
33 30 29 27 25 22
82 83 86 87 88 89 90
38 40 41 43 44
71 68 65 62 61 58
88 86 83 82 80 77
80 82 84 87 89 90
15 12 9 8 6 3
67 64 62 59 56
52 54 55 57 59
9 8 5 4 3 1
23 26 28 31 32 35 36
44 47 48 49 52 55 57
14 16 17 18 21 24
38 41 43 45 47 48
89 88 87 86 85 82
97 96 93 91 90 88 87
18 15 12 9 7 5
45 46 48 51 54 56 59 61
95 92 90 88 85 82
96 95 93 92 91 89 86
33 34 36 37 38
16 19 21 24 27 29
74 72 69 66 65 64 62
27 25 23 21 20 17
64 66 68 69 70 72 73 75
6 9 12 15 16 19 22
14 11 8 5 4 3 2
47 50 53 56 57 60 63
81 84 86 89 90
36 37 38 41 43 44
45 42 40 39 36 35 33 31
49 46 45 42 41 38
59 57 54 52 49 46 44
25 23 22 19 16
43 44 45 48 51
6 9 11 13 16
75 74 71 69 68 67 64
59 56 55 52 51
70 72 75 78 79
33 31 28 26 23 22 21
38 41 44 47 49
26 23 21 20 19
8 9 12 14 16 19 22
54 55 57 59 61
16 18 19 21 23 25
82 79 78 76 75 73 71 68
38 39 40 41 44
96 95 93 92 91 88 87
24 27 30 33 35 37 38
47 50 53 55 57 59 61
22 19 16 13 12 9
35 37 38 41 42 43
3 6 9 10 12 15 18
37 40 41 44 45
48 51 54 56 59 60 61 62
42 41 38 37 36 34 31 28
97 96 93 90 88 87
47 45 43 42 39 38
18 15 13 12 9 8 6
81 83 86 88 89 90 92 94
32 29 26 24 21 19 16 13
68 67 66 65 62 61 58 56
44 43 40 37 35 34 33
57 56 55 53 50 47 45
18 15 13 10 8 6
87 85 82 80 77 75
58 56 54 53 52 49 48
51 52 55 57 58 60
17 16 15 13 11 8
27 29 32 35 38 39 40 43
38 40 42 45 48 50 52 53
62 63 66 68 70
92 91 90 88 85 82 81 80
3 6 9 12 14
75 78 81 84 87 90
48 45 42 41 40 39
72 73 74 75 76 78 79
50 52 55 56 59 62
83 81 80 78 75 73 71 68
30 33 34 37 40 42
43 46 48 50 51 52
30 28 27 24 22 19
56 54 51 50 48 46 43 40
29 30 32 35 37 38 39 40
74 73 72 70 68 67
80 78 77 75 73
21 18 15 12 9 7 6
42 43 44 46 48 50 51
35 32 31 28 25 22
69 71 72 75 77
79 76 75 73 72 70 68
53 54 56 59 61 64 65
42 39 37 36 35
22 25 28 31 33
20 18 15 13 12 11 9
34 36 39 40 42 43 46 49
17 19 20 23 25 27 30
30 33 35 36 39 42 44
26 24 21 20 17 15
44 42 40 39 37
70 71 72 74 77 79 82
45 42 40 39 38 35 32 30
17 18 19 20 23 25 28 30
89 92 95 97 99
94 93 90 88 85 83
62 65 67 70 71 73
79 76 75 73 71 70
17 15 13 12 9 6 4
74 71 68 66 64 63 60
41 40 37 35 32 30 27 25
19 22 25 26 27
38 41 42 45 48 51
94 92 89 86 83 80
46 49 50 52 55 56 57
78 75 74 73 71 70 68";
}
