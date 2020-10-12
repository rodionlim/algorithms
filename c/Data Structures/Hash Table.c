// Implements a dictionary's functionality

#include <ctype.h>
#include <stdbool.h>
#include <stdio.h>
#include <string.h>
#include <strings.h>
#include <stdlib.h>

#include "dictionary.h"

// Represents number of buckets in a hash table
#define N 26

// Represents a node in a hash table
typedef struct node
{
    char word[LENGTH + 1];
    struct node *next;
}
node;

// Represents a hash table
node *hashtable[N];

// Hashes word to a number between 0 and 25, inclusive, based on its first letter
unsigned int hash(const char *word)
{
    return tolower(word[0]) - 'a';
}

// Loads dictionary into memory, returning true if successful else false
bool load(const char *dictionary)
{
    // Initialize hash table
    for (int i = 0; i < N; i++)
    {
        hashtable[i] = NULL;
    }

    // Open dictionary
    FILE *file = fopen(dictionary, "r");
    if (file == NULL)
    {
        unload();
        return false;
    }

    // Buffer for a word
    char word[LENGTH + 1];

    // Insert words into hash table
    while (fscanf(file, "%s", word) != EOF)
    {
        // TODO
        int h = hash(word);
        node *tmpNode = malloc(sizeof(node));
        if (tmpNode == NULL)
        {
            unload();
            return false;
        }

        strcpy(tmpNode->word, word);
        tmpNode->next = hashtable[h];
        hashtable[h] = tmpNode;
        //printf("%s %i\n",tmpNode->word, h);
    }

    // Close dictionary
    fclose(file);

    // Indicate success
    return true;
}

// Returns number of words in dictionary if loaded else 0 if not yet loaded
unsigned int size(void)
{
    // TODO
    int size = 0;
    node *currNode = NULL;

    for (int i=0, n=N; i<n; i++)
    {
        currNode = hashtable[i];
        while (currNode != NULL)
        {
            size++;
            //printf("%i %s\n", size, currNode->word);
            currNode = currNode->next;
        }
    }

    if (size == 0)
    {
        return 0;
    }
    else
    {
        return size;
    }
}

// Returns true if word is in dictionary else false
bool check(const char *word)
{
    // TODO
    int h = hash(word);
    node *trav = hashtable[h];

    while (trav != NULL)
    {
        if (strcasecmp(word, trav->word) == 0)
        {
            return true;
        }
        else
        {
            trav = trav->next;
        }
    }

    // Failed to match any of the words in Dict
    return false;
}

// Unloads dictionary from memory, returning true if successful else false
bool unload(void)
{
    // TODO
    node *trav = NULL;

    for (int i=0,n=N; i<n; i++)
    {
        trav = hashtable[i];
        while (trav != NULL)
        {
            node *travCurr = trav;
            trav = trav->next;
            free(travCurr);
        }
    }

    return true;
}
