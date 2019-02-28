import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpecialOfferMapper from '../specialOffer/specialOfferMapper';
import SpecialOfferViewModel from '../specialOffer/specialOfferViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface SpecialOfferTableComponentProps {
  specialOfferID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface SpecialOfferTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SpecialOfferViewModel>;
}

export class SpecialOfferTableComponent extends React.Component<
  SpecialOfferTableComponentProps,
  SpecialOfferTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SpecialOfferViewModel) {
    this.props.history.push(ClientRoutes.SpecialOffers + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SpecialOfferViewModel) {
    this.props.history.push(ClientRoutes.SpecialOffers + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.SpecialOfferClientResponseModel
          >;

          console.log(response);

          let mapper = new SpecialOfferMapper();

          let specialOffers: Array<SpecialOfferViewModel> = [];

          response.forEach(x => {
            specialOffers.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: specialOffers,
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
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'SpecialOffers',
                columns: [
                  {
                    Header: 'Category',
                    accessor: 'category',
                    Cell: props => {
                      return <span>{String(props.original.category)}</span>;
                    },
                  },
                  {
                    Header: 'Description',
                    accessor: 'description',
                    Cell: props => {
                      return <span>{String(props.original.description)}</span>;
                    },
                  },
                  {
                    Header: 'DiscountPct',
                    accessor: 'discountPct',
                    Cell: props => {
                      return <span>{String(props.original.discountPct)}</span>;
                    },
                  },
                  {
                    Header: 'EndDate',
                    accessor: 'endDate',
                    Cell: props => {
                      return <span>{String(props.original.endDate)}</span>;
                    },
                  },
                  {
                    Header: 'MaxQty',
                    accessor: 'maxQty',
                    Cell: props => {
                      return <span>{String(props.original.maxQty)}</span>;
                    },
                  },
                  {
                    Header: 'MinQty',
                    accessor: 'minQty',
                    Cell: props => {
                      return <span>{String(props.original.minQty)}</span>;
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'SpecialOfferID',
                    accessor: 'specialOfferID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.specialOfferID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'StartDate',
                    accessor: 'startDate',
                    Cell: props => {
                      return <span>{String(props.original.startDate)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SpecialOfferViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as SpecialOfferViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>ba5acfd165d4062bd524e91ee878d3c3</Hash>
</Codenesium>*/