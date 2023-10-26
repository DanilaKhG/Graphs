Чтобы запустить:

Открыть нужный проект, при этом нужно находиться в папке, где есть файл .csproj и запустить консоль с помощью "cmd"

Например: Graphs\Graphs3\Graphs3

Для работ 1-3 использовать:

dotnet run -l list_of_adjacency_t1_013.txt

dotnet run -m matrix_t3_002.txt

dotnet run -e list_of_edges_t3_008.txt

Для 4 работы:

dotnet run -- -l list_of_adjecency_t4_008.txt -p

Для 5 работы:

dotnet run -- -e list_of_edges_t5_001.txt -n 1 -d 5
после -n указать номер начальной вершины
после -d указать номер конечной вершины

Для 6 работы:

dotnet run -- -e list_of_edges_t6_009.txt -b -n 20
после -n указать номер начальной вершины

Для 7 работы:

dotnet run -- -e list_of_edges_t7_006.txt

Для 8 работы:

dotnet run -- -m map_007.txt -n 3 5 -d 7 20

Задания для работ находятся в папке Tasks
