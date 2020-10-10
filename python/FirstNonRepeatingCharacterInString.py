# Given a string, find the first non-repeating character in it. For example, if the input string is “GeeksforGeeks”,
# then the output should be ‘f’ and if the input string is “GeeksQuiz”, then the output should be ‘G’.


def getFirstNonRepeatingChar(input):
    origInput = input
    input = input.upper()
    currentPos = 1
    intermediateCharDict = {}

    for c in input:
        if not c in intermediateCharDict:
            intermediateCharDict[c] = currentPos
            currentPos += 1
        else:
            intermediateCharDict[c] = False

    remapDict = dict(zip(intermediateCharDict.values(), intermediateCharDict.keys()))

    if False in remapDict:
        remapDict.pop(False)

    firstCharUpper = remapDict.get(min(remapDict.keys()))
    for c in origInput:
        if c.upper() == firstCharUpper:
            return c
    return firstCharUpper


input = "GeeksforGeeks"
getFirstNonRepeatingChar(input)
