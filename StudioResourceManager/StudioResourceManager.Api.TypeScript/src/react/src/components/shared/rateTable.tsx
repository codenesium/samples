import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from '../rate/rateMapper';
import RateViewModel from '../rate/rateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface RateTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface RateTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<RateViewModel>;
}

export class  RateTableComponent extends React.Component<
RateTableComponentProps,
RateTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: RateViewModel) {
  this.props.history.push(ClientRoutes.Rates + '/edit/' + row.id);
}

handleDetailClick(e:any, row: RateViewModel) {
  this.props.history.push(ClientRoutes.Rates + '/' + row.id);
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
          let response = resp.data as Array<Api.RateClientResponseModel>;

          console.log(response);

          let mapper = new RateMapper();
          
          let rates:Array<RateViewModel> = [];

          response.forEach(x =>
          {
              rates.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: rates,
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
                    Header: 'Rates',
                    columns: [
					  {
                      Header: 'Amount Per Minute',
                      accessor: 'amountPerMinute',
                      Cell: (props) => {
                      return <span>{String(props.original.amountPerMinute)}</span>;
                      }           
                    },  {
                      Header: 'TeacherId',
                      accessor: 'teacherId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Teachers + '/' + props.original.teacherId); }}>
                          {String(
                            props.original.teacherIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'TeacherSkillId',
                      accessor: 'teacherSkillId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.TeacherSkills + '/' + props.original.teacherSkillId); }}>
                          {String(
                            props.original.teacherSkillIdNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as RateViewModel
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
                              row.original as RateViewModel
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
    <Hash>40239024ca9686efa2685b3f6d483ed3</Hash>
</Codenesium>*/