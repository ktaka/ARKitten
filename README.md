# ARKitten
技術評論社の月刊誌Software Designの「ARKitとUnityで作るiPhone ARアプリ集中特講」で開発するサンプルのリポジトリです。

![ARKitten](ARKitten.jpg)

[2018年4月号](http://gihyo.jp/magazine/SD/archive/2018/201804)の記事での完成状態がコミットされています。

2018年2月号での完成状態は[こちら](https://github.com/ktaka/ARKitten/tree/part_2)をご覧ください。

2018年3月号での完成状態は[こちら](https://github.com/ktaka/ARKitten/tree/part_3)をご覧ください。

## 2018年4月号
UnityのAsset Storeから[ARKitのプラグイン](http://u3d.as/RTd)と[Yughues Free Fabric Materials](https://assetstore.unity.com/packages/2d/textures-materials/fabric/yughues-free-fabric-materials-13002)をインポートしてからビルドしてください。

### アイコンのパッケージ
107ページから108ページにかけて使用する猫とボールのアイコンのパッケージは[こちらから](https://github.com/ktaka/ARKitten/raw/part_4t/arkitten_textures.unitypackage)ダウンロードしてください。

### 誌面掲載ソースコードの全文
- [リスト1 CatControl.cs](https://github.com/ktaka/ARKitten/blob/part_4_1t/Assets/CatControl.cs)
- [リスト2 FoodControl.cs](https://github.com/ktaka/ARKitten/blob/part_4_1t/Assets/FoodControl.cs)
- [リスト3 ControlAbstract.cs](https://github.com/ktaka/ARKitten/blob/part_4t/Assets/ControlAbstract.cs)
- [リスト4 CatControl.cs](https://github.com/ktaka/ARKitten/blob/part_4t/Assets/CatControl.cs)
- [リスト5 BallControl.cs](https://github.com/ktaka/ARKitten/blob/part_4t/Assets/BallControl.cs)
- [リスト6 FoodControl.cs](https://github.com/ktaka/ARKitten/blob/part_4t/Assets/FoodControl.cs)
- [リスト7 DropdownCallback.cs](https://github.com/ktaka/ARKitten/blob/part_4t/Assets/DropdownCallback.cs)

## Cute Kittenのアセット
このプロジェクトで使用している猫のモデルのアセット（Cute Kitten）は元はUnityのAsset Storeからダウンロード、インポートしていました。
アセットの作者の事情によりAsset Storeからはこのアセットはダウンロードできなくなってしまいましたが、このサンプルプロジェクトに含める許可を頂きました。
作者の[Alexey Kuznetsov](http://leshiy3d.com/)氏に感謝します。

### 利用方法
「完成状態のものを見るだけではつまらない、解説記事の手順に沿って自分で開発したい！」という方は、下記2つの進め方があります。
- [2月号での完成状態](https://github.com/ktaka/ARKitten/tree/part_2)から始める
  - プロジェクトウィンドウのAssetsの下に既にKittenフォルダがあり、3月号の記事の分から自分の手で進められます
- 自分で作ったプロジェクトにアセットのフォルダをコピーする
  - このリポジトリをClone、もしくは[ダウンロード](https://github.com/ktaka/ARKitten/archive/master.zip)する
  - Finder等でARKitten/Assetsのフォルダを開き、Kittenフォルダがあることを確認する
  - KittenフォルダをUnityのプロジェクトウィンドウのAssetsの下にドラッグ＆ドロップする
  - プロジェクトウィンドウのAssetsの下にKittenフォルダが作成され、Asset Storeからインポートした際と同じ状態になります
  - Cute Kittenのインポート部分以外は2月号、3月号の記事の手順の通りに進められます

Special thanks to [Alexey Kuznetsov](http://leshiy3d.com/), the creator of Cute Kitten.

## 日本語で質問出来るフォーラム
主にモバイル端末向けの[VRやARについて日本語で質問できるフォーラム](https://groups.google.com/d/forum/vr_ar_ja)があります。
ご質問等ありましたら、ぜひ[そちら](https://groups.google.com/d/forum/vr_ar_ja)からお願いします。
