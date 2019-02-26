import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FollowingMapper from '../following/followingMapper';
import FollowingViewModel from '../following/followingViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface FollowingTableComponentProps {
  user_id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface FollowingTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<FollowingViewModel>;
}

export class  FollowingTableComponent extends React.Component<
FollowingTableComponentProps,
FollowingTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: FollowingViewModel) {
  this.props.history.push(ClientRoutes.Followings + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: FollowingViewModel) {
   this.props.history.push(ClientRoutes.Followings + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.FollowingClientResponseModel>;

          console.log(response);

          let mapper = new FollowingMapper();
          
          let followings:Array<FollowingViewModel> = [];

          response.forEach(x =>
          {
              followings.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: followings,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'Followings',
                    columns: [
					  {
                      Header: 'Date_followed',
                      accessor: 'dateFollowed',
                      Cell: (props) => {
                      return <span>{String(props.original.dateFollowed)}</span>;
                      }           
                    },  {
                      Header: 'Muted',
                      accessor: 'muted',
                      Cell: (props) => {
                      return <span>{String(props.original.muted)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as FollowingViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as FollowingViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>d865a0b005f7bffc786f52cd4c05fee2</Hash>
</Codenesium>*/