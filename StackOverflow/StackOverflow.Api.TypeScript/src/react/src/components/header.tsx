import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from '../../node_modules/antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (Component: React.ComponentClass<any> | React.SFC<any>,
displayName:string) => {
  class WrapperHeaderComponent extends React.Component<WrapperHeaderProps & RouteComponentProps, WrapperHeaderState> {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
               <MenuItem
                key="Home"
				onClick={() =>  {this.setState({...this.state, collapsed:true})}}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'}></Link>
              </MenuItem>

			   			   <MenuItem
                key="badges"
              >
			  <Icon type="pie-chart" />
              <span>Badges</span>
              <Link to={ClientRoutes.Badges}></Link>
              </MenuItem>

							   <MenuItem
                key="comments"
              >
			  <Icon type="rise" />
              <span>Comments</span>
              <Link to={ClientRoutes.Comments}></Link>
              </MenuItem>

							   <MenuItem
                key="linkTypes"
              >
			  <Icon type="bars" />
              <span>Link Types</span>
              <Link to={ClientRoutes.LinkTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="postHistory"
              >
			  <Icon type="cloud" />
              <span>Post History</span>
              <Link to={ClientRoutes.PostHistory}></Link>
              </MenuItem>

							   <MenuItem
                key="postHistoryTypes"
              >
			  <Icon type="code" />
              <span>Post History Types</span>
              <Link to={ClientRoutes.PostHistoryTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="postLinks"
              >
			  <Icon type="smile" />
              <span>Post Links</span>
              <Link to={ClientRoutes.PostLinks}></Link>
              </MenuItem>

							   <MenuItem
                key="posts"
              >
			  <Icon type="laptop" />
              <span>Posts</span>
              <Link to={ClientRoutes.Posts}></Link>
              </MenuItem>

							   <MenuItem
                key="postTypes"
              >
			  <Icon type="mobile" />
              <span>Post Types</span>
              <Link to={ClientRoutes.PostTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="tags"
              >
			  <Icon type="paper-clip" />
              <span>Tags</span>
              <Link to={ClientRoutes.Tags}></Link>
              </MenuItem>

							   <MenuItem
                key="users"
              >
			  <Icon type="setting" />
              <span>Users</span>
              <Link to={ClientRoutes.Users}></Link>
              </MenuItem>

							   <MenuItem
                key="votes"
              >
			  <Icon type="user" />
              <span>Votes</span>
              <Link to={ClientRoutes.Votes}></Link>
              </MenuItem>

							   <MenuItem
                key="voteTypes"
              >
			  <Icon type="home" />
              <span>Vote Types</span>
              <Link to={ClientRoutes.VoteTypes}></Link>
              </MenuItem>

				
            </Menu>
          </Sider>
          <Layout>
            <Content style={{ margin: '0 16px' }}>
            <h2>{displayName}</h2>
			  <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
                <Component {...this.props} />
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};

/*<Codenesium>
    <Hash>ac3bb6ca76d9781731ae950269710992</Hash>
</Codenesium>*/