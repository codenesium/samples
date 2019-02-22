import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitOfficerMapper from './unitOfficerMapper';
import UnitOfficerViewModel from './unitOfficerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface UnitOfficerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UnitOfficerDetailComponentState {
  model?: UnitOfficerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UnitOfficerDetailComponent extends React.Component<
  UnitOfficerDetailComponentProps,
  UnitOfficerDetailComponentState
> {
  state = {
    model: new UnitOfficerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.UnitOfficers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.UnitOfficers +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.UnitOfficerClientResponseModel;

          console.log(response);

          let mapper = new UnitOfficerMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
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
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div style={{ marginBottom: '10px' }}>
              <h3>officerId</h3>
              <p>
                {String(this.state.model!.officerIdNavigation!.toDisplay())}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>unitId</h3>
              <p>{String(this.state.model!.unitIdNavigation!.toDisplay())}</p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedUnitOfficerDetailComponent = Form.create({
  name: 'UnitOfficer Detail',
})(UnitOfficerDetailComponent);


/*<Codenesium>
    <Hash>79b5131bb6cc8448a6d3b394e7596b93</Hash>
</Codenesium>*/