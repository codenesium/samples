import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface FamilyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FamilyDetailComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class FamilyDetailComponent extends React.Component<
  FamilyDetailComponentProps,
  FamilyDetailComponentState
> {
  state = {
    model: new FamilyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Families + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Families +
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
          let response = resp.data as Api.FamilyClientResponseModel;

          console.log(response);

          let mapper = new FamilyMapper();

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
      return <LoadingForm />;
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
            <div>
              <div>note</div>
              <div>{this.state.model!.note}</div>
            </div>
            <div>
              <div>primaryContactEmail</div>
              <div>{this.state.model!.primaryContactEmail}</div>
            </div>
            <div>
              <div>primaryContactFirstName</div>
              <div>{this.state.model!.primaryContactFirstName}</div>
            </div>
            <div>
              <div>primaryContactLastName</div>
              <div>{this.state.model!.primaryContactLastName}</div>
            </div>
            <div>
              <div>primaryContactPhone</div>
              <div>{this.state.model!.primaryContactPhone}</div>
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

export const WrappedFamilyDetailComponent = Form.create({
  name: 'Family Detail',
})(FamilyDetailComponent);


/*<Codenesium>
    <Hash>3ce3a393800ec6e6347c5deebc6f370f</Hash>
</Codenesium>*/