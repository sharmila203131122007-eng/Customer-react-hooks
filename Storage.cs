import { useState } from "react";

function useLocalStorage(key, initialValue) {
  const [value, setValue] = useState(() => {
    try {
      const saved = localStorage.getItem(key);
      return saved !== null
        ? JSON.parse(saved)
        : initialValue;
    } catch {
      return initialValue;
    }
  });

  function updateValue(newValue) {
    setValue((prev) => {
      const valueToStore =
        typeof newValue === "function"
          ? newValue(prev)
          : newValue;

      localStorage.setItem(
        key,
        JSON.stringify(valueToStore)
      );

      return valueToStore;
    });
  }

  return [value, updateValue];
}

export default useLocalStorage;
