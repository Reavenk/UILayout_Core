﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class UILStack
        {
            struct Entry
            {
                public EleBaseRect rect;
                public EleBaseSizer sizer;

                public Entry(EleBaseRect rect)
                { 
                    this.rect = rect;
                    this.sizer = null;
                }

                public Entry(EleBaseRect rect, EleBaseSizer sizer)
                { 
                    this.rect = rect;
                    this.sizer = sizer;
                }

                public EleBaseSizer GetSizer()
                { 
                    if(this.sizer != null)
                        return this.sizer;

                    return this.rect.Sizer;
                }
            }

            Factory uiFactory;

            Entry head;
            Stack<Entry> stack = new Stack<Entry>();

            public UILStack(Factory factory, EleBaseRect rect, EleBaseSizer sizer)
            { 
                this.uiFactory = factory;
                this.head = new Entry(rect, sizer);
            }

            public UILStack(Factory factory, EleBaseRect rect)
            { 
                this.uiFactory = factory;
                this.head = new Entry(rect, rect.Sizer);
            }

            public EleBoxSizer PushHorizSizer()
            { 
                return this.PushHorizSizer(0.0f, 0);
            }

            public EleBoxSizer AddHorizSizer()
            { 
                return this.AddHorizSizer(0.0f, 0);
            }

            public EleBoxSizer AddHorizSizer(float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                EleBoxSizer ret;

                if (szr == null)
                    ret = this.uiFactory.HorizontalSizer(this.head.rect);
                else
                    ret = this.uiFactory.HorizontalSizer(szr, proportion, flags);

                return ret;
            }

            public EleBoxSizer PushHorizSizer(float proportion, LFlag flags)
            {
                EleBoxSizer szr = this.AddHorizSizer(proportion, flags);
                if(szr == null)
                    return null;

                Entry newE = new Entry(this.head.rect, szr);
                this.stack.Push(this.head);
                this.head = newE;

                return szr;
            }

            public EleBoxSizer PushVertSizer()
            { 
                return this.PushVertSizer(0.0f, 0);
            }

            public EleBoxSizer AddVertSizer()
            {
                return this.AddVertSizer(0.0f, 0);
            }

            public EleBoxSizer AddVertSizer(float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                EleBoxSizer ret;

                if (szr == null)
                    ret = this.uiFactory.VerticalSizer(this.head.rect);
                else
                    ret = this.uiFactory.VerticalSizer(szr, proportion, flags);

                return ret;
            }

            public EleBoxSizer PushVertSizer(float proportion, LFlag flags)
            {
                EleBoxSizer szr = this.AddVertSizer(proportion, flags);
                if(szr == null)
                    return null;

                Entry newE = new Entry(this.head.rect, szr);
                this.stack.Push(this.head);
                this.head = newE;

                return szr;
            }

            public EleText AddText(string text, int fontSize, bool wrap, float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                if (szr == null)
                    return null;

                EleText ret = this.uiFactory.CreateText(this.head.rect, text, fontSize, wrap);
                szr.Add(ret, proportion, flags);
                return ret;
            }

            public EleText AddText(string text, bool wrap, float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                if (szr == null)
                    return null;
                
                EleText ret = this.uiFactory.CreateText(this.head.rect, text, wrap);
                szr.Add(ret, proportion, flags);
                return ret;
            }

            public EleImg AddImage(Sprite sprite, float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                if (szr == null)
                    return null;

                EleImg img = this.uiFactory.CreateImage(this.head.rect, sprite);
                szr.Add(img, proportion, flags);
                return img;
            }

            public EleImg PushImage(Sprite sprite, float proportion, LFlag flags)
            { 
                EleImg ret = this.AddImage(sprite, proportion, flags);
                if(ret == null)
                    return null;

                this.stack.Push(this.head);

                this.head = new Entry(ret);
                return ret;
            }

            public EleButton AddButton(string text, float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                if (szr == null)
                    return null;

                EleButton btn = this.uiFactory.CreateButton(this.head.rect, text);
                szr.Add(btn, proportion, flags);
                return btn;
            }

            public EleButton PushButton(string text, float proportion, LFlag flags)
            {
                EleButton ret = this.AddButton(text, proportion, flags);
                if (ret == null)
                    return null;

                this.stack.Push(this.head);

                this.head = new Entry(ret);
                return ret;
            }

            public EleGenButton<ty> AddButton<ty>(string text, float proportion, LFlag flags) where ty : UnityEngine.UI.Button
            {
                EleBaseSizer szr = this.head.GetSizer();
                if (szr == null)
                    return null;

                EleGenButton<ty> btn = this.uiFactory.CreateButton<ty>(this.head.rect, text);
                szr.Add(btn, proportion, flags);
                return btn;
            }

            public EleGenButton<ty> PushButton<ty>(string text, float proportion, LFlag flags) where ty : UnityEngine.UI.Button
            {
                EleGenButton<ty> ret = this.AddButton<ty>(text, proportion, flags);
                if (ret == null)
                    return null;

                this.stack.Push(this.head);

                this.head = new Entry(ret);
                return ret;
            }

            public EleVertScrollRgn AddVertScrollRect(float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                if (szr == null)
                    return null;

                EleVertScrollRgn srgn = this.uiFactory.CreateVerticalScrollRect(this.head.rect);
                szr.Add(srgn, proportion, flags);
                return srgn;
            }

            public EleVertScrollRgn PushVertScrollRect(float proportion, LFlag flags)
            {
                EleVertScrollRgn ret = this.AddVertScrollRect(proportion, flags);
                if (ret == null)
                    return null;

                this.stack.Push(this.head);

                this.head = new Entry(ret);
                return ret;
            }


            public EleSpace AddSpace(float size, float proportion, LFlag flags)
            { 
                return this.AddSpace(new Vector2(size, size), proportion, flags);
            }

            public EleSpace AddHorizSpace(float width, float proportion, LFlag flags)
            { 
                return this.AddSpace(new Vector2(width, 0.0f), proportion, flags);
            }

            public EleSpace AddVertSpace(float height, float proportion, LFlag flags)
            { 
                return this.AddSpace(new Vector2(0.0f, height), proportion, flags);
            }

            public EleSpace AddSpace(Vector2 sz, float proportion, LFlag flags)
            {
                EleBaseSizer szr = this.head.GetSizer();
                if(szr == null)
                    return null;

                EleSpace space = new EleSpace(sz);
                szr.Add(space, proportion, flags);
                return space;
            }

            public bool Pop()
            { 
                if(stack.Count == 0)
                    return false;

                this.head = stack.Pop();

                return true;
            }
        }
    }
}
