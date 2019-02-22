import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BadgeMapper from '../badge/badgeMapper';
import BadgeViewModel from '../badge/badgeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface BadgeTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface BadgeTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<BadgeViewModel>;
}

export class  BadgeTableComponent extends React.Component<
BadgeTableComponentProps,
BadgeTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: BadgeViewModel) {
  this.props.history.push(ClientRoutes.Badges + '/edit/' + row.id);
}

handleDetailClick(e:any, row: BadgeViewModel) {
  this.props.history.push(ClientRoutes.Badges + '/' + row.id);
}

  componentDidMount() {
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
          let response = resp.data as Array<Api.BadgeClientResponseModel>;

          console.log(response);

          let mapper = new BadgeMapper();
          
          let badges:Array<BadgeViewModel> = [];

          response.forEach(x =>
          {
              badges.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: badges,
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
                    Header: 'Badges',
                    columns: [
					  {
                      Header: 'Date',
                      accessor: 'date',
                      Cell: (props) => {
                      return <span>{String(props.original.date)}</span>;
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'UserId',
                      accessor: 'userId',
                      Cell: (props) => {
                      return <span>{String(props.original.userId)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as BadgeViewModel
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
                              row.original as BadgeViewModel
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
    <Hash>3f8bb58737e48fbf5d8faec4bbae3b89</Hash>
</Codenesium>*/