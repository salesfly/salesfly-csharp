.PHONY: test build pack

test:
	dotnet test ./Salesfly.Tests/

build:
	dotnet build ./Salesfly/

pack:
	dotnet pack -c Release ./Salesfly/ 

clean:
	dotnet clean ./Salesfly/
	dotnet clean ./Salesfly.Tests/
