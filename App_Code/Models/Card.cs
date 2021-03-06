﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Card
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual Card Parent { get; set; }

    public virtual IList<Card> Children { get; set; }

    public virtual IList<Content> Contents { get; set; }

    public static IEnumerable<Card> GetParents(Card card)
    {
        yield return card;

        if (card.Parent != null) {
            foreach (var cardParent in GetParents(card.Parent)) {
                yield return cardParent;
            }
        }
    }
}

public class Content
{
    [Key]
    public int Id { get; set; }

    public virtual Card Parent { get; set; }

    public DateTime? DateCreated { get; set; }
}

public class Comment : Content
{
    public string Text { get; set; }
}