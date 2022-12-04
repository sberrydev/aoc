param(
    [Parameter(Mandatory=$true)]
    [string]$name,
    [ValidatePattern('Day[0-9]{2}')]
    [string]$day
)

if (!$day) {
    $numericDay = (Get-Date).ToString("dd")
    $day = "Day$numericDay"
} else {
    $numericDay = $day.Substring(3,2)
}

 dotnet new aoc --day $day --challenge $name --output "../../AdventOfCode2022"
    
 bash -c "./GetInput.sh '$numericDay'"