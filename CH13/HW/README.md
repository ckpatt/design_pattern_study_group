![](https://i.imgur.com/4OwxW6x.png)

先把所有保鑣所需的技能，放入 abstract class `GuardBuilder`。當要新增一個保鑣來面試時，都要繼承此 `GuardBuilder`，以免在新增保鑣物件時漏掉必須實做的 method。接著再透過 `director` 的 `pass_stage_one` 跟 `stage_two` 來表示面試關卡。