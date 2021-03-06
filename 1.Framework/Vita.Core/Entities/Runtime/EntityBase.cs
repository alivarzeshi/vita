﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Vita.Entities.Authorization;

namespace Vita.Entities.Runtime {

  // Default base class for entity classes
  public abstract class EntityBase : INotifyPropertyChanged {
    public readonly EntityRecord Record;

    public EntityBase(EntityRecord record) {
      Record = record;
    }

    public override string ToString() {
      return Record.ToString(); 
    }

    public override int GetHashCode() {
      return Record.GetHashCode(); //return PrimaryKey.GetHashCode()
    }

    public override bool Equals(object other) {
      if(other == null)
        return false;
      if(other == (object)this)
        return true;
      var otherEntBase = other as EntityBase;
      if(otherEntBase == null)
        return false; 
      var otherRec = otherEntBase.Record;
      return (this.Record.PrimaryKey.Equals(otherRec.PrimaryKey));
    }

    #region INotifyPropertyChanged Members
    event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged {
      add { Record.PropertyChanged += value; }
      remove {  Record.PropertyChanged -= value; }
    }
    #endregion


  }//class

  public class EntityComparer<T> : IEqualityComparer<T> {

    #region IEqualityComparer<T> Members

    public bool Equals(T x, T y) {
      throw new NotImplementedException();
    }

    public int GetHashCode(T obj) {
      throw new NotImplementedException();
    }

    #endregion
  }
}

